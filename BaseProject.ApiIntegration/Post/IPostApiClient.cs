using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.FavoriteSave;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ApiIntegration.Post
{
    public interface IPostApiClient
    {
        Task<ApiResult<PagedResult<PostVm>>> GetUsersPagings(GetUserPagingRequest request);
        Task<ApiResult<PagedResult<PostVm>>> GetAllPostPagings(GetUserPagingRequest request);
        Task<ApiResult<bool>> CreateOrUpdatePost(PostCreateRequest request);
        Task<ApiResult<bool>> Check(AddSaveVm request);
        Task<ApiResult<bool>> UpdatePost(int idPost, PostCreateRequest request);
        Task<ApiResult<bool>> DeletePost(int idPost);
        Task<ApiResult<bool>> Lock(Guid UserId ,int idPost, string Message);

        Task<ApiResult<PostCreateRequest>> GetById(int id);
        Task<List<PostVm>> TakeTopByQuantity(int quantity);

        Task<List<Location>> GetAll();

        Task<ApiResult<bool>> Like(AddSaveVm model);

    }
}
