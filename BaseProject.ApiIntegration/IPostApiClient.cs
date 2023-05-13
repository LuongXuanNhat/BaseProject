using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ApiIntegration
{
    public interface IPostApiClient
    {
        Task<ApiResult<PagedResult<PostVm>>> GetUsersPagings(GetUserPagingRequest request);
        Task<ApiResult<bool>> CreatePost(PostCreateRequest request);

        Task<ApiResult<bool>> UpdatePost(int idPost, PostCreateRequest request);
        Task<ApiResult<bool>> DeletePost(int idPost);

        Task<ApiResult<CategoryRequest>> GetById(int id);

        

    }
}
