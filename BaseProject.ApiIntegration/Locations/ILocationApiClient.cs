using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;

namespace BaseProject.ApiIntegration.Locations
{
    public interface ILocationApiClient
    {
        Task<ApiResult<PagedResult<LocationCreateRequest>>> GetUsersPagings(GetUserPagingRequest request);
        Task<ApiResult<PagedResult<LocationVm>>> GetPlacesPagings(GetUserPagingRequest request);
        Task<ApiResult<bool>> RegisterOrUpdate(LocationCreateRequest request);

        Task<ApiResult<bool>> Update(LocationCreateRequest request);
        Task<ApiResult<bool>> Delete(int locationId);
        Task<List<LocationVm>> TakeByQuantity(int quantity);

        Task<ApiResult<LocationCreateRequest>> GetById(int id);
        Task<ApiResult<LocationDetailRequest>> GetByIdDetail(int id, GetUserPagingRequest request);



    }
}
