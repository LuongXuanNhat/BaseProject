using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.Catalog.Posts
{
    public interface IPostService
    {
        Task<ApiResult<bool>> CreateOrUpdate(PostCreateRequest request);

        Task<ApiResult<bool>> Update(int id, PostCreateRequest request);

        Task<string> Delete(int postId);
        Task<ApiResult<bool>> GetList(int userId);

        Task<ApiResult<PagedResult<PostVm>>> GetPostPaging(GetUserPagingRequest request);
        Task<ApiResult<PagedResult<PostVm>>> GetPostPagingUser(GetUserPagingRequest request);

        Task<ApiResult<PostCreateRequest>> GetById(int postId);
        Task<List<SearchPlaceVm>> GetAll(string searchText);
        
    }
}
