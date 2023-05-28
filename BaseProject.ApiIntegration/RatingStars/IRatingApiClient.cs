using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Catalog.RatingStar;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ApiIntegration.RatingStars
{
    public interface IRatingApiClient
    {
        Task<ApiResult<bool>> UpdatePost(int id, int stars);
        Task<ApiResult<bool>> DeletePost(int id);

        Task<ApiResult<RatingLocationDetailVm>> GetById(int id);
        Task<ApiResult<PagedResult<RatingLocationDetailVm>>> GetByUserName(GetUserPagingRequest getRatingListPagingRequest);

        Task<List<RatingLocationDetailVm>> GetAll();
    }
}
