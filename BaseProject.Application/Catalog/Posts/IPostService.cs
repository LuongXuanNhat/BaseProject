using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.FavoriteSave;
using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.Catalog.Posts
{
    public interface IPostService
    {
        Task<Like> Check(string UserName, int Id);
        Task<ApiResult<bool>> CreateOrUpdate(PostCreateRequest request);

        Task<ApiResult<bool>> Update(int id, PostCreateRequest request);

        Task<string> Delete(int postId);
        Task<ApiResult<bool>> GetList(int userId);
        Task<ApiResult<bool>> Like(AddSaveVm request);
        Task<ApiResult<bool>> Enable(PostEnable request);

        Task<ApiResult<PagedResult<PostVm>>> GetPostPaging(GetUserPagingRequest request);
        Task<ApiResult<PagedResult<PostVm>>> GetPostFollowPaging(GetUserPagingRequest request);
        Task<ApiResult<PagedResult<PostVm>>> GetPostPagingAdmin(GetUserPagingRequest request);
        Task<ApiResult<PagedResult<PostVm>>> GetPostPagingUser(GetUserPagingRequest request);

        Task<ApiResult<PostCreateRequest>> GetByIdAdmin(int postId);
        Task<ApiResult<PostCreateRequest>> GetById(int postId);

        Task<List<PostVm>> TakeTopByQuantity(int quantity);

        Task<List<SearchPlaceVm>> GetAll(string searchText);
        
    }
}
