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
using BaseProject.ViewModels.Catalog.Location;
using Microsoft.AspNetCore.Http;
using BaseProject.Application.Catalog.Categories;
using BaseProject.Application.Catalog.Images;

namespace BaseProject.Application.Catalog.Posts
{
    public class PostService : IPostService
    {
        private readonly DataContext _context;
        private readonly IStorageService _storageService;
        private readonly ICategoryService _categoryService;
        private readonly IImageService _imageService;
        private readonly UserManager<AppUser> _userManager;


        public PostService(DataContext context, 
            UserManager<AppUser> userManager, 
            ICategoryService categoryService,
            IImageService imageService)
        {
            _userManager = userManager;
            _context = context;
            _categoryService = categoryService;
            _imageService = imageService;
        }
        public async Task<ApiResult<bool>> CreateOrUpdate(PostCreateRequest request)
        {
            if (request == null)
            {
                return new ApiErrorResult<bool>("Lỗi");
            }
            if (request.PostId != null && request.PostId != 0)
            {
                Post post = new Post()
                {
                    PostId = request.PostId,
                    Title = request.Title
                };

                // Gắn vào ngữ cảnh
                _context.Posts.Attach(post);
                // Các thuộc tính thay đổi sẽ được cập nhập
                _context.Entry(post).Property(p => p.Title).IsModified = true;
                await _context.SaveChangesAsync();

                // Lưu Category detail
                if (request.CategoryPostDetail != null && request.CategoryPostDetail.Count != 0)
                {
                    var saveCategoryPost = await _categoryService.Update( request.PostId, request.CategoryPostDetail);

                }

                // Lưu chi tiết đánh giá
                for (int i = 0; i < request.PostDetail.Count; i++)
                {
                    Location location = new Location();
                    location = await _context.Locations.FirstOrDefaultAsync(str => str.Address.Equals(request.PostDetail[i].Address));
                    LocationsDetail locationsDetail = new LocationsDetail(
                        request.PostDetail[i].postDetailId,
                        location.LocationId,
                        post.PostId,
                        request.PostDetail[i].Title,
                        request.PostDetail[i].When,
                        request.PostDetail[i].Content
                    );
                    _context.LocationsDetails.Update(locationsDetail);
                    await _context.SaveChangesAsync();

                    // Lưu PostDetail Image
                    if (request.PostDetail[i].GetImage != null && request.PostDetail[i].GetImage.Count != 0)
                    {
                        var saveImage = await _imageService.UpdateImage(request.PostDetail[i].GetImage, locationsDetail.Id);

                    }
                }


                return new ApiSuccessResult<bool>();
            }
            else
            {
                // Lưu Bài đánh giá 
                var user = from getId
                           in _context.Users
                           where getId.UserName == request.UserId
                           select getId.Id;
                Guid userId = user.First();

                Post post = new Post(request.Title, userId);
                _context.Posts.AddAsync(post);
                await _context.SaveChangesAsync();

                // Lưu Category detail
                var postID = post.PostId;
                var saveCategoryPost = await _categoryService.SaveCatelogyDetail(request.CategoryPostDetail, postID);


                // Lưu chi tiết đánh giá
                for (int i = 0; i < request.PostDetail.Count; i++)
                {
                    Location location = new Location();
                    location = await _context.Locations.FirstOrDefaultAsync(str => str.Address.Equals(request.PostDetail[i].Address));
                    LocationsDetail locationsDetail = new LocationsDetail(
                        location.LocationId,
                        post.PostId,
                        request.PostDetail[i].Title,
                        request.PostDetail[i].When,
                        request.PostDetail[i].Content
                    );
                    _context.LocationsDetails.AddAsync(locationsDetail);
                    await _context.SaveChangesAsync();

                    // Lưu PostDetail Image
                    if (request.PostDetail[i].GetImage != null && request.PostDetail[i].GetImage.Count != 0)
                    {
                        var saveImage = await _imageService.UpdateImage(request.PostDetail[i].GetImage, locationsDetail.Id);

                    }
                }


                return new ApiSuccessResult<bool>();
            }
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

            var cate = await _categoryService.GetAll();
            var newPost = new PostCreateRequest()
            {
                PostId = postId,
                UserId = post.UserId.ToString(),
                PostDetail = list,
                Title = post.Title,
                CategoryPostDetail = cate.ResultObj

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

        public async Task<List<SearchPlaceVm>> GetAll(string searchText)
        {
            var result = await _context.Locations
                        .Where(l => l.Name.Contains(searchText))
                        .ToListAsync();

            List<SearchPlaceVm> placeList = new List<SearchPlaceVm>();
            for (int i = 0; i < result.Count; i++)
            {
                SearchPlaceVm place = new SearchPlaceVm(); // Khởi tạo đối tượng SearchPlaceVm
                place.LocationId = result[i].LocationId;
                place.Name = result[i].Name;
                place.Address = result[i].Address;
                place.PlaceImage = await _context.Images.Where(x => x.LocationId == result[i].LocationId).Select(x => x.Path).FirstOrDefaultAsync();
                placeList.Add(place);
            }
            return placeList;
        }


    }
}