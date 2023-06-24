using Azure.Core;
using BaseProject.Application.Catalog.Images;
using BaseProject.Application.Common;
using BaseProject.Application.System.Users;
using BaseProject.Data.EF;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BaseProject.Application.Catalog.Searchs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BaseProject.Application.Catalog.Locations
{
    public class LocationService : ILocationService
    {

        private readonly DataContext _context;
        private readonly IImageService _imageService;
        private readonly ISearchService _searchService;
        private readonly IUserService _userService;
        private const string USER_CONTENT_FOLDER_NAME = "Images";

        public LocationService(DataContext context, IImageService imageService, ISearchService searchService, IUserService userService )
        {
            _context = context;
            _imageService = imageService;
            _searchService = searchService;
            _userService = userService;
        }

        public async Task<ApiResult<bool>> CreateOrUpdate(LocationCreateRequest request)
        {
            Location location = await _context.Locations.FirstOrDefaultAsync(x => x.LocationId == request.LocationId);

            if (location != null)
            {
                if (request.LocationId != 0)
                {
                    location.Name = request.Name;
                    location.Address = request.Address;
                    location.Description = request.Description;

                    _context.Locations.Update(location);   
                    if (request.GetImage != null && request.GetImage.Count != 0)
                    {
                        var saveImagePlace = await _imageService.UpdateImage(request.GetImage, location);
                        if (saveImagePlace != null && saveImagePlace.IsSuccessed == true)
                        {
                            await _context.SaveChangesAsync();
                            return new ApiSuccessResult<bool>();
                        }
                    }                   
                    return new ApiSuccessResult<bool>();
                } 
                
            }
            else
            {
                var Location = new Location()
                {
                    Name = request.Name,
                    Address = request.Address

                };
                // Lưu địa điểm
                
                _context.Locations.Add(Location);
                _context.SaveChanges();


                // Lưu ảnh
                if (request.GetImage != null)
                {
                    Location findID = await _context.Locations.FirstOrDefaultAsync(x => x.Address.Equals(location.Address));
                    var saveImage = await _imageService.SaveImage(request.GetImage, findID);
                    if (saveImage != null && saveImage.IsSuccessed == true)
                    {
                        return new ApiSuccessResult<bool>();
                    }
                     else   return new ApiErrorResult<bool>("Lỗi lưu ảnh");
                }
   
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Update(int id, LocationCreateRequest request)
        {
            if (id == null)
            {
                return new ApiErrorResult<bool>("Lỗi cập nhập");
            }

           // Không sử dụng update này
           // _context.Locations.Update(request);
            _context.SaveChanges();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Delete(int locationId)
        {
            if (locationId == null)
            {
                return new ApiErrorResult<bool>("Lỗi cập nhập");
            }
            var location = await _context.Locations.FirstOrDefaultAsync(x => x.LocationId == locationId);

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<PagedResult<LocationCreateRequest>>> GetLocationPaging(GetUserPagingRequest request)
        {
            var query = await _context.Locations.ToListAsync();
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Name.Contains(request.Keyword)).ToList();
            }

            //3. Paging
            int totalRow = query.Count();

            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new LocationCreateRequest()
                {
                    LocationId = x.LocationId,
                    Name = x.Name,
                    Address = x.Address
                }).ToList();

            //4. Select and projection
            var pagedResult = new PagedResult<LocationCreateRequest>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<LocationCreateRequest>>(pagedResult);
        }
        public async Task<ApiResult<PagedResult<LocationVm>>> GetLocationPagingByKeys(GetUserPagingRequest request)
        {
            
            // get all địa điểm
            List<string> keys = new List<string>();
            var query = await _context.Locations.ToListAsync();

            if (request.number == 1)
            {
                if (!string.IsNullOrEmpty(request.Keyword))
                {
                    query = query.Where(x => x.Address.Contains(request.Keyword2.ToString()) && x.Name.Contains(request.Keyword, StringComparison.OrdinalIgnoreCase)).ToList();

                    if (request.UserName != null)
                    {
                        keys.Add(request.Keyword);
                        keys.Add("Tìm kiếm địa điểm trong tỉnh "+ request.Keyword2);
                        Guid UserID = await _userService.GetIdByUserName(request.UserName);
                        await _searchService.Add(UserID, keys);
                    }
                }
                else
                {
                    query = query.Where(x => x.Address.Contains(request.Keyword2.ToString())).ToList();
                    
                    if (request.UserName != null)
                    {
                        keys.Add(request.Keyword2);
                        Guid UserID = await _userService.GetIdByUserName(request.UserName);
                        await _searchService.Add(UserID, keys);
                    }
                }

            }
            // 2: Category Location
            else if (request.number == 2)
            {
                var cateId = await _context.Categories.FirstOrDefaultAsync(x=>x.Name.Equals(request.Keyword2));
                if (!string.IsNullOrEmpty(request.Keyword) && cateId != null)
                {
                    // Lấy danh sách địa điểm 
                    var cate_list = await _context.CategoriesLocations.Where(x => x.CategoriesId == cateId.CategoriesId).ToListAsync();
                    query = query.Where(x => cate_list.Any(p => p.LocationId == x.LocationId)).ToList();
                    query = query.Where(x => x.Name.Contains(request.Keyword, StringComparison.OrdinalIgnoreCase)).ToList();
                    if (request.UserName != null)
                    {
                        keys.Add(request.Keyword);
                        keys.Add("Tìm kiếm địa điểm trong danh mục " + request.Keyword2);
                        
                        Guid UserID = await _userService.GetIdByUserName(request.UserName);
                        await _searchService.Add(UserID, keys);
                    }
                        
                }
                else
                {
                    if (cateId != null)
                    {
                        // Lấy danh sách địa điểm nằm trong cate đó
                        var cate_list = await _context.CategoriesLocations.Where(x => x.CategoriesId == cateId.CategoriesId).ToListAsync();
                        query = query.Where(x => cate_list.Any(p => p.LocationId == x.LocationId)).ToList();

                        if (request.UserName != null)
                        {
                            keys.Add("Tìm kiếm địa điểm trong danh mục " + request.Keyword2);
                            Guid UserID = await _userService.GetIdByUserName(request.UserName);
                             await _searchService.Add(UserID, keys);
                        }
                            
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(request.Keyword))
                        {
                            query = query.Where(x => x.Name.Contains(request.Keyword, StringComparison.OrdinalIgnoreCase)).ToList();

                            if (request.UserName != null)
                            {
                                keys.Add(request.Keyword);
                                Guid UserID = await _userService.GetIdByUserName(request.UserName);
                                await _searchService.Add(UserID, keys);
                            }
                                
                        }
                    }
                }
            } else if (request.number == 3)
            {
                //Sắp xếp theo view cao đến thấp
                query =  query.OrderByDescending(item => item.View).ToList();

            } else if (request.number == 4)
            {
                var getRatings = await _context.RatingLocations.ToListAsync();

                query = query.OrderByDescending(location =>
                    getRatings.Count(rating => rating.LocationId == location.LocationId)
                ).ToList();

            } else if (request.number == 5)
            {
                var getPosts = await _context.LocationsDetails.ToListAsync();

                query = query.OrderByDescending(location =>
                    getPosts.Count(rating => rating.LocationId == location.LocationId)
                ).ToList();
            } else if (request.number == 6)
            {
                var getLocationSaves = await _context.Saveds.ToListAsync();

                query = query.OrderByDescending(location =>
                    getLocationSaves.Count(rating => rating.LocationId == location.LocationId)
                ).ToList();
            }

            //3. Paging
            int totalRow =  query.Count();

            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x =>
                     new LocationVm()
                     {
                         LocationId = x.LocationId, // Sử dụng bản sao của x.LocationId
                         Name = x.Name,
                         Address = x.Address,
                         ImageList = (from tb in _context.Images
                                      where tb.LocationId == x.LocationId
                                      select tb.Path).FirstOrDefault(),
                         View = x.View == null ? 0 : x.View,
                     }).ToList();

            //4. Select and projection
            var pagedResult = new PagedResult<LocationVm>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize, 
                Items = data
            };
            return new ApiSuccessResult<PagedResult<LocationVm>>(pagedResult);
        }

        
        public async Task<ApiResult<LocationCreateRequest>> GetById(int locationId)
        {
            var location = await _context.Locations.Where(x => x.LocationId == locationId).FirstOrDefaultAsync();
            if (location == null)
            {
                return new ApiErrorResult<LocationCreateRequest>("Địa điểm không tồn tại");
            }
            var query = await _context.Images.Where(x => x.LocationId.Equals(location.LocationId)).Select(x=> x.Path).ToListAsync();

            

            var updateLocationRequest = new LocationCreateRequest()
            {
                LocationId = location.LocationId,
                Name = location.Name,
                Address = location.Address,
                ImageList = query.ToList()
            };
            
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<LocationCreateRequest>(updateLocationRequest);
        }

        // Chi tiết địa điểm
        public async Task<ApiResult<LocationDetailRequest>> GetByIdDetail(int locationId, GetUserPagingRequest request)
        {
            var location = await _context.Locations.Where(x => x.LocationId == locationId).FirstOrDefaultAsync();
            if (location == null)
            {
                return new ApiErrorResult<LocationDetailRequest>("Địa điểm không tồn tại");
            }

            if (location.View == null)
            {
                location.View = 1;
            }
            else location.View += 1;

            _context.Update(location);
            await _context.SaveChangesAsync();

            // Lấy ảnh
            var img_list = await _context.Images.Where(x => x.LocationId.Equals(location.LocationId)).Select(x => x.Path).ToListAsync();

            // Lấy số liệu đánh giá
            int rating_count;
            double rating_score;
            int review_count = await _context.LocationsDetails.Where(x=>x.LocationId == location.LocationId).CountAsync();
            var rating_list = await _context.RatingLocations.Where(x => x.LocationId.Equals(location.LocationId) && ((int)x.Check) == 1).ToListAsync();
            if (!rating_list.Any()) {
                rating_count = 0;
                rating_score = 0;
            }
            else
            {
                rating_count = rating_list.Count();
                int rating_sum = rating_list.Sum(x => x.Stars.HasValue ? x.Stars.Value : 0);
                rating_score = Math.Ceiling((rating_sum * 1.0 / rating_count) * 10) / 10;
            }
            var savecount = await _context.Saveds.Where(x=>x.LocationId == location.LocationId).CountAsync();

            // Lấy danh sách bài đánh giá - 11 thuộc tính
            // Lấy chỉ số postID
            var result = await _context.LocationsDetails
                .Where(x=>x.LocationId == location.LocationId)
                .Select(x=>x.PostId).Distinct()
                .ToListAsync();

            // Lấy post
            List<Post> posts = new List<Post>();
            for(int i=0; i< result.Count; i++)
            {
                var reponse = await _context.Posts.Where(x=>x.PostId == result[i]).FirstOrDefaultAsync();
                posts.Add(reponse);
                
            }
            posts = posts.OrderByDescending(x => x.PostId).Where(x=> x.Check == 0).ToList();
            // Lấy postDetail
            PagedResult<PostDetailRequest> list = new PagedResult<PostDetailRequest>();
            list.Items = new List<PostDetailRequest>();
            foreach (Post post in posts)
            {
                var postDetails = await _context.LocationsDetails.Where(x=>x.PostId == post.PostId ).ToListAsync();
                
                // Lấy 1post - 1postDetail
                    PostDetailRequest postDetailRequest = new PostDetailRequest();
                    postDetailRequest.PostId = post.PostId;
                    var User = await _context.Users.Where(x => x.Id == post.UserId).FirstOrDefaultAsync();
                    postDetailRequest.UserName = User.UserName;
                    postDetailRequest.UserId = User.Id;
                    postDetailRequest.Title = post.Title;
                    postDetailRequest.Content = post.LocationsDetail[0].Content;
                    postDetailRequest.When = post.LocationsDetail[0].When; 
                    postDetailRequest.postDetailId = post.LocationsDetail[0].Id;
                    postDetailRequest.ImageList = await _context.Images.Where(x => x.LocationsDetailId == postDetailRequest.postDetailId).Select(x => x.Path).ToListAsync();
                    postDetailRequest.Address = await _context.Locations.Where(x => x.LocationId == post.LocationsDetail[0].LocationId).Select(x => x.Address).FirstOrDefaultAsync();

                    var shareCount = await _context.Shares.Where(x => x.PostId == post.PostId).CountAsync();
                    var saveCount = await _context.Saveds.Where(x => x.PostId == post.PostId).CountAsync();
                    var commentCount = await _context.Comments.Where(x => x.PostId == post.PostId).CountAsync();
                    var likeCount = await _context.Likes.Where(x => x.PostId == post.PostId).CountAsync();
             //       var ratingStar = await _context.RatingLocations.ToListAsync();

                    postDetailRequest.ShareCount = shareCount;
                    postDetailRequest.SaveCount = saveCount;
                    postDetailRequest.CommentCount = commentCount;
                    postDetailRequest.LikeCount = likeCount;

                    try
                    {
                        list.Items.Add(postDetailRequest);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("Đã xảy ra lỗi khi thêm postDetailRequest vào danh sách: " + ex.Message);
                    }
                    
            }
            // phân trang
            int totalRow = list.Items.Count();
            var data = list.Items.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            //4. Select and projection
            var pagedResult = new PagedResult<PostDetailRequest>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };

            // Chuyển vào view model - hiển thị ra ngoài

            var updateLocationRequest = new LocationDetailRequest()
            {
                LocationId = location.LocationId,
                Name = location.Name,
                Address = location.Address,
                Description = "Thông tin mô tả về địa điểm này đang được cập nhập",
                View = location.View,
                RatingCount = rating_count,
                RatingScore = rating_score,
                ReviewPostCount = review_count,
                SaveCount = savecount,
                ImageList = img_list.ToList() ?? null ,
                PagedPostResult = pagedResult,
            };




            return new ApiSuccessResult<LocationDetailRequest>(updateLocationRequest);
        }

        public async Task<List<LocationVm>> TakeByQuantity(int quantity)
        {
            var location = await _context.Locations.ToListAsync();
            List<Location> locationVms = new List<Location>();
            Random random = new Random();

            while (locationVms.Count < 6)
            {
                int index = random.Next(0, location.Count);
                Location randomLocation = location[index];

                if (!locationVms.Contains(randomLocation))
                {
                    locationVms.Add(randomLocation);
                }
            }


            List<LocationVm> getList = new List<LocationVm>();
            foreach (var item in locationVms)
            {
                LocationVm location1 = new LocationVm();
                location1.LocationId = item.LocationId;
                location1.Address = item.Address;
                location1.Name = item.Name;
                location1.ImageList = await _imageService.GetById(item.LocationId);

                getList.Add(location1);
            }
            return getList;
        }
    }
}
