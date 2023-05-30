using Azure.Core;
using BaseProject.Application.Catalog.Images;
using BaseProject.Application.Common;
using BaseProject.Data.EF;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Application.Catalog.Categories
{
    public class LocationService : ILocationService
    {

        private readonly DataContext _context;
        private readonly IImageService _imageService;
        private const string USER_CONTENT_FOLDER_NAME = "Images";

        public LocationService(DataContext context, IImageService imageService)
        {
            _context = context;
            _imageService = imageService;
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
            var query = await _context.Locations.ToListAsync();

            if (request.number == 1)
            {
                if (!string.IsNullOrEmpty(request.Keyword))
                {
                    query = query.Where(x => x.Address.Contains(request.Keyword2.ToString()) && x.Name.Contains(request.Keyword, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                else
                {
                    query = query.Where(x => x.Address.Contains(request.Keyword2.ToString())).ToList();
                }

            }
            // 2: Category Location
            if (request.number == 2)
            {
                var cateId = await _context.Categories.FirstOrDefaultAsync(x=>x.Name.Equals(request.Keyword2));
                if (!string.IsNullOrEmpty(request.Keyword) && cateId != null)
                {
                    // Lấy danh sách địa điểm nằm trong cate đó
                    var cate_list = await _context.CategoriesLocations.Where(x => x.CategoriesId == cateId.CategoriesId).ToListAsync();
                    query = query.Where(x => cate_list.Any(p => p.LocationId == x.LocationId)).ToList();
                    query = query.Where(x => x.Name.Contains(request.Keyword, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                else
                    if (cateId != null)
                {
                    var cate_list = await _context.CategoriesLocations.Where(x => x.CategoriesId == cateId.CategoriesId).ToListAsync();
                    query = query.Where(x => cate_list.Any(p => p.LocationId == x.LocationId)).ToList();
                }
                    else
                    {
                        if (!string.IsNullOrEmpty(request.Keyword))
                        {
                            query = query.Where(x => x.Name.Contains(request.Keyword, StringComparison.OrdinalIgnoreCase)).ToList();
                        }
                    }
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

            return new ApiSuccessResult<LocationCreateRequest>(updateLocationRequest);
        }

        public async Task<ApiResult<LocationDetailRequest>> GetByIdDetail(int locationId)
        {
            var location = await _context.Locations.Where(x => x.LocationId == locationId).FirstOrDefaultAsync();
            if (location == null)
            {
                return new ApiErrorResult<LocationDetailRequest>("Địa điểm không tồn tại");
            }
            // Lấy ảnh
            var img_list = await _context.Images.Where(x => x.LocationId.Equals(location.LocationId)).Select(x => x.Path).ToListAsync();

            // Lấy số liệu đánh giá
            int rating_count;
            double rating_score;
            int review_count = await _context.LocationsDetails.Where(x=>x.LocationId == location.LocationId).CountAsync();
            var rating_list = await _context.RatingLocations.Where(x => x.LocationId.Equals(location.LocationId) && x.Stars != null).ToListAsync();
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

            // Lấy postDetail
            List<PostDetailRequest> list = new List<PostDetailRequest>();
            foreach(Post post in posts)
            {
                var postDetails = await _context.LocationsDetails.Where(x=>x.PostId == post.PostId).ToListAsync();
                
                // Lấy 1post - 1postDetail
                if( postDetails != null && postDetails.Count == 1 ) {
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

                    var shareCount = _context.Shares.Where(x => x.PostId == post.PostId).Count();
                    var saveCount = _context.Saveds.Where(x => x.PostId == post.PostId).Count();

                    postDetailRequest.ShareCount = shareCount;
                    postDetailRequest.SaveCount = saveCount;

                    list.Add(postDetailRequest);
                } else
                {
                    if (postDetails != null && postDetails.Count > 1)
                    {
                        for (int i = 0; i < post.LocationsDetail.Count; i++)
                        {
                            PostDetailRequest postDetailRequest = new PostDetailRequest();
                            postDetailRequest.PostId = post.PostId;
                            var User = await _context.Users.Where(x => x.Id == post.UserId).FirstOrDefaultAsync();

                            postDetailRequest.UserName = User.UserName;
                            postDetailRequest.UserId = User.Id;
                            postDetailRequest.Title = post.Title;
                            postDetailRequest.Content = post.LocationsDetail[i].Content;
                            postDetailRequest.When = post.LocationsDetail[i].When;

                            postDetailRequest.postDetailId = post.LocationsDetail[i].Id;

                            postDetailRequest.ImageList = await _context.Images.Where(x => x.LocationsDetailId == postDetailRequest.postDetailId).Select(x => x.Path).ToListAsync();

                            postDetailRequest.Address = await _context.Locations.Where(x => x.LocationId == post.LocationsDetail[i].LocationId).Select(x => x.Address).FirstOrDefaultAsync();

                            var shareCount = _context.Shares.Where(x => x.PostId == post.PostId).Count();
                            var saveCount = _context.Saveds.Where(x => x.PostId == post.PostId).Count();

                            postDetailRequest.ShareCount = shareCount;
                            postDetailRequest.SaveCount = saveCount;

                            list.Add(postDetailRequest);
                        }
                    }
                }

            }


            var updateLocationRequest = new LocationDetailRequest()
            {
                LocationId = location.LocationId,
                Name = location.Name,
                Address = location.Address,
                Description = "Thông tin mô tả về địa điểm này đang được cập nhập",
                View = location.View == null ? 0 : location.View,
                RatingCount = rating_count,
                RatingScore = rating_score,
                ReviewCount = review_count != null ? review_count : null,
                ImageList = img_list.ToList() == null ? null : img_list.ToList(),
                PostDetailRequest = list == null ? null : list,
            };

            return new ApiSuccessResult<LocationDetailRequest>(updateLocationRequest);
        }
    }
}
