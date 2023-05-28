using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.Catalog.RatingStar;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.Catalog.Categories
{
    public interface IRatingService
    {
        Task<bool> Create(Guid userID, int LocationID);
        Task<bool> Update(int id, int star_number);
        Task<ApiResult<bool>> Delete(int categoryId);

        Task<ApiResult<PagedResult<LocationCreateRequest>>> GetLocationPaging(GetUserPagingRequest request);

        Task<ApiResult<LocationCreateRequest>> GetById(int locationId);
        Task<ApiResult<PagedResult<RatingLocationDetailVm>>> GetByUserName(GetUserPagingRequest request);
        


    }
}
