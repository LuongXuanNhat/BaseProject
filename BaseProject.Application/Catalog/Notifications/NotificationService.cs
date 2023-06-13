using BaseProject.Application.System.Users;
using BaseProject.Data.EF;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
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
        private readonly IUserService _userService;


        public NotificationService(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<ApiResult<List<NoticeDetail>>> GetAll(string userName)
        {
            var userId = await _userService.GetIdByUserName(userName);
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
            var userId = await _userService.GetIdByUserName(request.Keyword);
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
    }
}
