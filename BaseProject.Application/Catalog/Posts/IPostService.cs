using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.Catalog.Posts
{
    public interface IPostService
    {
        Task<ApiResult<bool>> Create(PostCreateRequest request);

        Task<ApiResult<bool>> Update(int id, PostCreateRequest request);

        Task<ApiResult<bool>> Delete(int categoryId);

        Task<ApiResult<PagedResult<PostCreateRequest>>> GetPostPaging(GetUserPagingRequest request);

        Task<ApiResult<PostCreateRequest>> GetById(int categoryId);
    }
}
