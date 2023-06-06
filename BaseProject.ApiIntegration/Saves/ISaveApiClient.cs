using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.FavoriteSave;
using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Catalog.RatingStar;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ApiIntegration.Saves
{
    public interface ISaveApiClient
    {
        Task<ApiResult<bool>> AddToArchive(AddSaveVm request);
        Task<ApiResult<bool>> Check(AddSaveVm request);
        Task<ApiResult<PagedResult<LocationVm>>> GetByUserName(GetUserPagingRequest getRatingListPagingRequest);

    }
}
