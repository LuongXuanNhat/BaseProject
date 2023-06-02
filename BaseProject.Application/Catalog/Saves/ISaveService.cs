using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
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

namespace BaseProject.Application.Catalog.Saves
{
    public interface ISaveService
    {
        Task<bool> Create(Guid userID, int LocationID);
        Task<bool> AddPlaces(string UserName, int PlacesId);
        Task<ApiResult<bool>> Delete(int categoryId);

        Task<ApiResult<PagedResult<LocationVm>>> GetLocationPaging(GetUserPagingRequest request);
        Task<ApiResult<PagedResult<PostVm>>> GetPostPaging(GetUserPagingRequest request);

      //  Task<ApiResult<LocationCreateRequest>> GetById(int locationId);
        


    }
}
