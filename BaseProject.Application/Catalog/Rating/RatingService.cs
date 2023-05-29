using Azure.Core;
using BaseProject.Application.Catalog.Images;
using BaseProject.Application.Common;
using BaseProject.Data.EF;
using BaseProject.Data.Entities;
using BaseProject.Data.Enums;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Catalog.RatingStar;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Application.Catalog.Categories
{
    public class RatingService : IRatingService
    {

        private readonly DataContext _context;


        public RatingService(DataContext context)
        {
            _context = context;

        }

        public async Task<bool> Create(Guid userID, int LocationID)
        {
            var CreateRating = new RatingLocation()
            {
                LocationId = LocationID,
                UserId = userID,
                Date = DateTime.UtcNow,
                Stars = null,
                Check = 0
            };
            _context.RatingLocations.Add(CreateRating);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Rating(int id, int star_number)
        {
            var star = await _context.RatingLocations.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (star == null)
            {
                return false;
            }

         //   star.LocationId = star.Id;
         //   star.UserId = star.UserId;
            star.Date = DateTime.UtcNow;
            star.Stars = star_number;
            star.Check = YesNo.yes;

            // Cập nhật dữ liệu vào database
          //  _context.RatingLocations.Update(star);
            _context.SaveChanges();

            return true;
        }

        public async Task<ApiResult<bool>> Delete(int locationId)
        {
            if (locationId == null)
            {
                return new ApiErrorResult<bool>("Lỗi cập nhập");
            }
            var location = await _context.Locations.FirstOrDefaultAsync(x => x.LocationId == locationId);

            _context.Locations.Remove(location);
            _context.SaveChanges();
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
        public async Task<ApiResult<PagedResult<LocationVm>>> GetLocationPagingByProvince(GetUserPagingRequest request)
        {
            var query = await _context.Locations.ToListAsync();
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Address.Contains(request.Keyword2.ToString()) && x.Name.Contains(request.Keyword, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                query = query.Where(x => x.Address.Contains(request.Keyword2.ToString())).ToList();
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

        public async Task<ApiResult<PagedResult<RatingLocationDetailVm>>> GetByUserName(GetUserPagingRequest request)
        {
            var userID = await _context.Users.Where(x => x.UserName.Equals(request.Keyword)).Select(x => x.Id).FirstOrDefaultAsync();
            if (userID == null)
            {
                return new ApiErrorResult<PagedResult<RatingLocationDetailVm>>();
            }

            var list = await _context.RatingLocations.Where(x => x.UserId == userID).ToListAsync();
            if (list == null)
            {
                return new ApiSuccessResult<PagedResult<RatingLocationDetailVm>>();
            }

            var RatingList = new List<RatingLocationDetailVm>();

            //3. Paging
            int totalRow = list.Count();

            var data = list
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x =>
                {
                    var places = GetPlaceName(x.LocationId);
                    return new RatingLocationDetailVm()
                    {
                        Id = x.Id,
                        UserId = x.UserId,
                        Date = x.Date,
                        Stars = x.Stars == null ? 0 : x.Stars,
                        LocationId = x.LocationId,
                        LocationName = places.Name,
                        Address = places.Address,
                        Check = x.Check
                    };
                })
                .ToList();

            //4. Select and projection
            var pagedResult = new PagedResult<RatingLocationDetailVm>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<RatingLocationDetailVm>>(pagedResult);
        }

        private Location GetPlaceName(int locationId)
        {
            return _context.Locations.Where(x => x.LocationId == locationId).FirstOrDefault();
        }
    }
}
