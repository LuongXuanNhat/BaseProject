using BaseProject.Data.Entities;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.Catalog.Notifications
{
    public interface INotificationService
    {
        Task<ApiResult<List<NoticeDetail>>> GetAll(string userName);
        Task<bool> AddNotificationDetail(Guid User ,int Id,string content);
        Task<ApiResult<bool>> DeleteNotification(string usename);
        Task<ApiResult<PagedResult<NoticeDetail>>> GetNotificationPaging(GetUserPagingRequest request);
    }
}
