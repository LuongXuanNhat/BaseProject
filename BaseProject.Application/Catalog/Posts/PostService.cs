using BaseProject.Application.Common;
using BaseProject.Data.EF;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
                Location location = new Location();
                location = await _context.Locations.FirstOrDefaultAsync(x => x.Name.Contains(request.PostDetail[i].Title));
                if ( location == null )
                {

                    Location createLocation = new Location(request.PostDetail[i].Title, request.PostDetail[i].Address);
                    _context.Locations.AddAsync(createLocation);
                    _context.SaveChangesAsync();
                    location = await _context.Locations.FirstOrDefaultAsync(x => x.Name.Contains(request.PostDetail[i].Title));
                }
                LocationsDetail locationsDetail = new LocationsDetail(
                    location.LocationId ,
                    post.PostId,
                    post.Title,
                    request.PostDetail[i].When,
                    request.PostDetail[i].Content
                );
                _context.LocationsDetails.AddAsync(locationsDetail);
                _context.SaveChangesAsync();
            }


            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Update(int id, PostCreateRequest request)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.PostId == request.PostId);

            if (request == null)
            {
                return new ApiErrorResult<bool>("Lỗi");
            }

            // Lưu Bài đánh giá 
            //var user = from getId
            //                   in _context.Users
            //           where getId.UserName == request.UserId
            //           select getId.Id;
            //Guid userId = user.First();

            _context.Posts.Update(post);
            _context.SaveChangesAsync();

            // Lưu chi tiết đánh giá
            for (int i = 0; i < request.PostDetail.Count; i++)
            {
                Location location = new Location();
                location = await _context.Locations.FirstOrDefaultAsync(x => x.Name.Contains(request.PostDetail[i].Title));
                if (location == null)
                {

                    Location createLocation = new Location(request.PostDetail[i].Title, request.PostDetail[i].Address);
                    _context.Locations.AddAsync(createLocation);
                    _context.SaveChangesAsync();
                    location = await _context.Locations.FirstOrDefaultAsync(x => x.Name.Contains(request.PostDetail[i].Title));
                }
                LocationsDetail locationsDetail = new LocationsDetail(
                    location.LocationId,
                    post.PostId,
                    post.Title,
                    request.PostDetail[i].When,
                    request.PostDetail[i].Content
                );
                _context.LocationsDetails.Update(locationsDetail);
                _context.SaveChangesAsync();
            }


            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Delete(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<PostCreateRequest>> GetById(int postId)
        {
            var post = await _context.Posts.Where(x => x.PostId == postId).FirstOrDefaultAsync();
            if (post == null)
            {
                return new ApiErrorResult<PostCreateRequest>("Danh mục không tồn tại");
            }

            var postDetail = await _context.LocationsDetails.Where(x => x.PostId == postId).ToListAsync();
            List<PostDetailRequest> list = new List<PostDetailRequest>();
                for (int i = 0; i < postDetail.Count; i++)
                {
                    list[i].Title = postDetail[i].Title;

                    var address = await _context.Locations.FirstOrDefaultAsync(x => x.LocationId == postDetail[i].LocationId);
                    list[i].Address = address.Address;
                    list[i].Content = postDetail[i].Content;
                    list[i].When = postDetail[i].When;

                }

            var newPost = new PostCreateRequest()
            {
                PostId = postId,
                UserId = post.UserId.ToString(),
                PostDetail = list,
                Title = post.Title

            };
            return new ApiSuccessResult<PostCreateRequest>(newPost);
        }

        public async Task<ApiResult<PagedResult<PostVm>>> GetPostPaging(GetUserPagingRequest request)
        {
            var query = await _context.Posts.ToListAsync();
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Title.Contains(request.Keyword)).ToList();
            }

            //3. Paging
            int totalRow = query.Count();

            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new PostVm()
                {
                   PostId = x.PostId,
                   Title = x.Title,
                   Date = x.UploadDate,
                   UserId = x.UserId,
                   View = x.View
                }).ToList();

            //4. Select and projection
            var pagedResult = new PagedResult<PostVm>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<PostVm>>(pagedResult);
        }

        // Lấy danh sách theo tên user
        [Authorize]
        public async Task<ApiResult<PagedResult<PostVm>>> GetPostPagingUser(GetUserPagingRequest request)
        {
            var User = await _context.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName);

            var query =  _context.Posts.Where(x=> x.UserId.ToString() == User.Id.ToString()).ToList();
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Title.Contains(request.Keyword)).ToList();
            }

            //3. Paging
            int totalRow = query.Count();

            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new PostVm()
                {
                    PostId = x.PostId,
                    Title = x.Title,
                    Date = x.UploadDate,
                    UserId = x.UserId,
                    View = x.View
                }).ToList();

            //4. Select and projection
            var pagedResult = new PagedResult<PostVm>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<PostVm>>(pagedResult);
        }
        
    }
}
