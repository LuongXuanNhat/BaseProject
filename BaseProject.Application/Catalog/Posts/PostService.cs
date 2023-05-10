using BaseProject.Application.Common;
using BaseProject.Data.EF;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace BaseProject.Application.Catalog.Posts
{
    public class PostService : IPostService
    {
        private readonly DataContext _context;
        private readonly IStorageService _storageService;
        private readonly UserManager<AppUser> _userManager;


        public PostService(DataContext context, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<ApiResult<bool>> Create(PostCreateRequest request)
        {
            if (request == null)
            {
                return new ApiErrorResult<bool>("Lỗi");
            }

            // Lưu Bài đánh giá 
            var user =         from getId 
                               in _context.Users 
                               where getId.UserName == request.UserId
                               select getId.Id;
            Guid userId =      user.First();

            Post post = new Post(request.Title, userId);
            _context.Posts.AddAsync(post);
            _context.SaveChangesAsync();

            // Lưu chi tiết đánh giá
            for (int i = 0; i < request.PostDetail.Count; i++)
            {
                int location = _context.Locations.FirstOrDefaultAsync(x => x.Name == request.PostDetail[i].Title).Id;
                LocationsDetail locationsDetail = new LocationsDetail(
                    location,
                    post.PostId,
                    request.PostDetail[i].Title,
                    request.PostDetail[i].When,
                    request.PostDetail[i].Content
                );
                _context.LocationsDetails.AddAsync(locationsDetail);
                _context.SaveChangesAsync();
            }


            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Delete(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<PostCreateRequest>> GetById(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<PagedResult<PostCreateRequest>>> GetPostPaging(GetUserPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<bool>> Update(int id, PostCreateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
