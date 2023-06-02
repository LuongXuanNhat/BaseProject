using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.Catalog.Locations
{
    public interface ILocationService
    {
        Task<ApiResult<bool>> CreateOrUpdate(LocationCreateRequest request);

        Task<ApiResult<bool>> Update(int id, LocationCreateRequest request);

        Task<ApiResult<bool>> Delete(int categoryId);

        Task<ApiResult<PagedResult<LocationCreateRequest>>> GetLocationPaging(GetUserPagingRequest request);
        Task<ApiResult<PagedResult<LocationVm>>> GetLocationPagingByKeys(GetUserPagingRequest request);

        Task<ApiResult<LocationCreateRequest>> GetById(int locationId);
        Task<List<LocationVm>> TakeByQuantity(int quantity);
        Task<ApiResult<LocationDetailRequest>> GetByIdDetail(int locationId);
        


    }
}
