using BaseProject.Application.Common;
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

namespace BaseProject.Application.Catalog.Reports
{
    public class ReportService : IReportService
    {
        private readonly DataContext _context;
        private readonly IUserService _userService;


        public ReportService(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<ApiResult<bool>> Create(Report request)
        {
            request.UserId = await _userService.GetIdByUserName(request.UserName);

            _context.Reports.Add(request);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<PagedResult<Report>>> GetAll(GetUserPagingRequest request)
        {
            var query = await _context.Reports.OrderByDescending(p => p.Id).ToListAsync();
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Content.Contains(request.Keyword)).ToList();
            }

            //3. Paging
            int totalRow = query.Count();

            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            //4. Select and projection
            var pagedResult = new PagedResult<Report>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<Report>>(pagedResult);
        }

        // Trường hợp chấp nhập khóa bài viết
        public async Task<ApiResult<bool>> Lock(Guid UserId, int idPost, string Message, int ReportId)
        {
            //  Khóa bài viết
            if (idPost == null || idPost == 0)
            {
                // Tạo thông báo ( TB Hệ thống = 1 ) -> Gửi người báo cáo
                var noficationDetail = new NoticeDetail();
                noficationDetail.Notification = await _context.Notifications.Where(x => x.NotificationId == 1).FirstOrDefaultAsync();
                noficationDetail.Content = Message;
                noficationDetail.UserId = UserId;
                _context.NoticeDetails.Add(noficationDetail);

                var report = await _context.Reports.FirstOrDefaultAsync(x=>x.Id == ReportId);
                report.IsRead = Data.Enums.YesNo.yes;
                _context.Reports.Update(report);

                await _context.SaveChangesAsync();

            } else
            {
                var post = await _context.Posts.Where(x => x.PostId == idPost).FirstOrDefaultAsync();
                var report = await _context.Reports.FirstOrDefaultAsync(x => x.Id == ReportId);
                report.IsRead = Data.Enums.YesNo.yes;
                _context.Reports.Update(report);

                if (post == null)
                {
                    return new ApiErrorResult<bool>("Không tìm thấy bài viết");
                }

                post.Check = Data.Enums.YesNo.yes;
                _context.Posts.Update(post);
                

                // Tạo thông báo ( TB Hệ thống = 1 ) -> Gửi người báo cáo
                var noficationDetail = new NoticeDetail();
                noficationDetail.Notification = await _context.Notifications.Where(x => x.NotificationId == 1).FirstOrDefaultAsync();
                noficationDetail.Content = Message;
                noficationDetail.UserId = UserId;
                _context.NoticeDetails.Add(noficationDetail);

                // Tạo thông báo 2                     -> Gửi người bị báo cáo
                var noficationDetail_2 = new NoticeDetail();
                var userId = await _context.Posts.Where(x => x.PostId == idPost).Select(x => x.UserId).FirstOrDefaultAsync();
                if (userId != null)
                {
                    var post_lock = await _context.Posts.FirstOrDefaultAsync(x => x.PostId == idPost);

                    noficationDetail_2.Notification = await _context.Notifications.Where(x => x.NotificationId == 1).FirstOrDefaultAsync();
                    noficationDetail_2.UserId = userId;
                    noficationDetail_2.Content = "Bài viết có tiêu đề: " + post_lock.Title + " đã bị khóa do vi phạm nội dung ngăn cấm của chúng tôi! Nếu bạn có bất kỳ thắc mắc hay khiếu nại hãy gửi phản hồi qua hòm thư";
                    _context.NoticeDetails.Add(noficationDetail_2);
                }

                await _context.SaveChangesAsync();
            }
            


            return new ApiSuccessResult<bool>();
        }
    }

}
