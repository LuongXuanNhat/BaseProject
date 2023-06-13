using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ApiIntegration.Nofications
{
    public interface INoficationApiClient
    {
        Task<ApiResult<List<NoticeDetail>>> GetNofiUser(string UserName);
        Task<ApiResult<PagedResult<NoticeDetail>>> GetUsersPagings(GetUserPagingRequest request);
    }
}
