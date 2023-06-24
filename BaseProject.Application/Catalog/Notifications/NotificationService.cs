using BaseProject.Application.System.Users;
using BaseProject.Data.EF;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.Catalog.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly DataContext _context;


        public NotificationService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNotificationDetail(Guid User, int Id, string content)
        {
            // Kiểm tra trùng lặp trong 1 ngày của user nhận thông báo
            var check = await _context.NoticeDetails
                .Where(x=>x.UserId == User && x.Content.Equals(content) && x.Date.Date == DateTime.Now.Date)
                .FirstOrDefaultAsync();
            if (check == null)
            {
                // Thêm thông báo
                var Noti = await _context.Notifications.Where(x => x.NotificationId == Id).FirstOrDefaultAsync();
                NoticeDetail noticeDetail = new NoticeDetail()
                {
                    UserId = User,
                    Date = DateTime.Now,
                    Content = content,
                    NotificationId = Id,
                    Notification = Noti
                };

                _context.NoticeDetails.Add(noticeDetail);
                await _context.SaveChangesAsync();

                
                return true;
            }
            return false;

            
        }
        public async Task<ApiResult<bool>> DeleteNotification(string usename)
        {
            var UserId = await GetIdByUserName(usename);

            var query = await _context.NoticeDetails.Where(x => x.UserId == UserId).ToListAsync();


            _context.NoticeDetails.RemoveRange(query);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }
        public async Task<ApiResult<List<NoticeDetail>>> GetAll(string userName)
        {
            var userId = await GetIdByUserName(userName);
            var cate = await _context.NoticeDetails.OrderByDescending(x=>x.Id).Where(x=>x.UserId == userId).ToListAsync();
            foreach (var notice in cate)
            {
                notice.Notification = await _context.Notifications.FirstOrDefaultAsync(x => x.NotificationId == notice.NotificationId);
            }

            return new ApiSuccessResult<List<NoticeDetail>>(cate);
        }


        // Thông báo của User
        public async Task<ApiResult<PagedResult<NoticeDetail>>> GetNotificationPaging(GetUserPagingRequest request)
        {
            var userId = await GetIdByUserName(request.Keyword);
            var query = await _context.NoticeDetails.OrderByDescending(x => x.Id).Where(x=>x.UserId == userId).ToListAsync();
            foreach (var notice in query)
            {
                notice.IsRead = Data.Enums.YesNo.yes;
                notice.Notification = await _context.Notifications.FirstOrDefaultAsync(x => x.NotificationId == notice.NotificationId);
                _context.NoticeDetails.Update(notice);
            }
            await _context.SaveChangesAsync();


            //3. Paging
            int totalRow = query.Count();

            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize).ToList();

            //4. Select and projection
            var pagedResult = new PagedResult<NoticeDetail>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<NoticeDetail>>(pagedResult);
        }

        // Lấy ID từ UserName
        public async Task<Guid> GetIdByUserName(string username)
        {
            var user = await _context.Users.Where(x=>x.UserName == username).FirstOrDefaultAsync();
            return user.Id;
        }
    }
}
