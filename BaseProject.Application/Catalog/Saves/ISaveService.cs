using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.FavoriteSave;
using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;


namespace BaseProject.Application.Catalog.Saves
{
    public interface ISaveService
    {
        Task<Saved> Check(string UserName, int PlacesId, int number);
        Task<ApiResult<bool>> AddPlacesOrDelete(string UserName, int PlacesId);
        Task<ApiResult<bool>> AddPostsOrDelete(string UserName, int PostId);
        int CountById(Guid Id, int PostId);
        Task<ApiResult<bool>> Delete(string usename, int number);

        Task<ApiResult<PagedResult<LocationVm>>> GetLocationPaging(GetUserPagingRequest request);
        Task<ApiResult<PagedResult<PostVm>>> GetPostPaging(GetUserPagingRequest request);
        


    }
}
