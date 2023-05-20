using BaseProject.Application.Common;
using BaseProject.Data.EF;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authorization;



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
            var user = from getId
                               in _context.Users
                       where getId.UserName == request.UserId
                       select getId.Id;
            Guid userId = user.First();

            Post post = new Post(request.Title, userId);
            _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();

            // Lưu chi tiết đánh giá
            for (int i = 0; i < request.PostDetail.Count; i++)
            {
                Location location = new Location();
                location = await _context.Locations.FirstOrDefaultAsync(str => str.Address.Equals(request.PostDetail[i].Address));
                if (location == null)
                {

                    Location createLocation = new Location(request.PostDetail[i].Title, request.PostDetail[i].Address);
                    _context.Locations.AddAsync(createLocation);
                    await _context.SaveChangesAsync();
                    location = await _context.Locations.FirstOrDefaultAsync(x => x.Name.Contains(request.PostDetail[i].Title));
                }
                LocationsDetail locationsDetail = new LocationsDetail(
                    location.LocationId,
                    post.PostId,
                    request.PostDetail[i].Title,
                    request.PostDetail[i].When,
                    request.PostDetail[i].Content
                );
                _context.LocationsDetails.AddAsync(locationsDetail);
                await _context.SaveChangesAsync();
            }


            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Update(int id, PostCreateRequest request)
        {
            //  Lưu bài viết

            if (request == null)
            {
                return new ApiErrorResult<bool>("Lỗi");
            }
            Post post = new Post()
            {
                UserId = Guid.Parse(request.UserId),
                PostId = id,
                Title = request.Title
            };

            _context.Posts.Update(post);
            await _context.SaveChangesAsync();

            var createLocations = new List<Location>();
            // Lưu địa điểm mới
            for (int i = 0; i < request.PostDetail.Count; i++)
            {
                Location location = new Location();
                location = await _context.Locations.FirstOrDefaultAsync(str => str.Address.Equals(request.PostDetail[i].Address));
                if (location == null)
                {
                    var location1 = new Location(request.PostDetail[i].Title, request.PostDetail[i].Address);
                    createLocations.Add(location1);
                }

            }
            if (createLocations.Count > 0)
            {
                try
                {
                    _context.AddRange(createLocations);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi tại đây, ví dụ in ra thông báo lỗi:
                    Console.WriteLine(ex.Message);
                }
            }


            // Lưu chi tiết địa điểm, bài viết
            for (int i = 0; i < request.PostDetail.Count; i++)
            {
                var location = _context.Locations.FirstOrDefault(x => x.Address.Contains(request.PostDetail[i].Address));

                LocationsDetail locationsDetail = new LocationsDetail(
                    location.LocationId,
                    post.PostId,
                    request.PostDetail[i].Title,
                    request.PostDetail[i].When,
                    request.PostDetail[i].Content
                );
                try
                {
                    _context.LocationsDetails.Update(locationsDetail);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi tại đây, ví dụ in ra thông báo lỗi:
                    Console.WriteLine(ex.Message);
                }

            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<string> Delete(int postId)
        {
            var post = await _context.Posts.Where(x => x.PostId == postId).FirstOrDefaultAsync();
            var postDetail = await _context.LocationsDetails.Where(x => x.PostId == postId).ToListAsync();
            if (post == null)
            {
                return null;
            }
            var user = await _context.Users.Where(x => x.Id == post.UserId).FirstOrDefaultAsync();

            _context.Posts.Remove(post);
            _context.LocationsDetails.RemoveRange(postDetail);
            await _context.SaveChangesAsync();

            if (user != null)
            {
                return user.UserName.ToString();
            }
            return null;

        }




        public async Task<ApiResult<PostCreateRequest>> GetById(int postId)
        {
            var post = await _context.Posts.Where(x => x.PostId == postId).FirstOrDefaultAsync();
            if (post == null)
            {
                return new ApiErrorResult<PostCreateRequest>("Bài viết không tồn tại");
            }

            var postDetail = await _context.LocationsDetails.Where(x => x.PostId == postId).ToListAsync();
            var location = await _context.Locations.ToListAsync();

            Location address = new Location();
            List<PostDetailRequest> list = new List<PostDetailRequest>();
            for (int i = 0; i < postDetail.Count; i++)
            {
                PostDetailRequest item = new PostDetailRequest();
                item.Title = postDetail[i].Title;
                address = location.FirstOrDefault(x => x.LocationId == postDetail[i].LocationId);
                item.Address = address.Address;
                item.Content = postDetail[i].Content;
                item.When = postDetail[i].When;
                list.Add(item);
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

            var query = _context.Posts.Where(x => x.UserId.ToString() == User.Id.ToString()).ToList();
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Title.Contains(request.Keyword)).ToList();
            }
            if (query.Count == 0) { query = _context.Posts.Where(x => x.UserId.ToString() == User.Id.ToString()).ToList(); }
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

        public async Task<ApiResult<bool>> GetList(int userId)
        {
            return new ApiSuccessResult<bool>();
        }

        public async Task<List<Location>> GetAll(string searchText)
        {
            var result = await _context.Locations
                        .Where(l => l.Name.Contains(searchText))
                        .ToListAsync();
            return result;
        }


    }
}