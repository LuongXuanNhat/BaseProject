using Azure.Core;
using BaseProject.Application.Catalog.Images;
using BaseProject.Application.Common;
using BaseProject.Application.System.Users;
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

namespace BaseProject.Application.Catalog.Saves
{
    public class SaveService : ISaveService
    {

        private readonly DataContext _context;
        private readonly IUserService _userService;


        public SaveService(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
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

        // Lưu địa điểm vào danh mục yêu thích
        public async Task<bool> AddPlaces(string UserName, int PlacesId)
        {
            var UserId = await _userService.GetIdByUserName(UserName);
            var item = new Saved()
            {
                PostId = null,
                UserId = UserId,
                LocationId = PlacesId,
                Date = DateTime.UtcNow
            };
            _context.Saveds.Add(item);
            await _context.SaveChangesAsync();

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

        public async Task<ApiResult<PagedResult<LocationVm>>> GetLocationPaging(GetUserPagingRequest request)
        {
            var UserId = await _userService.GetIdByUserName(request.UserName);
            var getLocationId = await _context.Saveds.Where(x=>x.UserId == UserId && x.LocationId != 0).Select(x=>x.LocationId).ToListAsync();
            var query = await _context.Locations.Where(x => getLocationId.Contains(x.LocationId)).ToListAsync();

            //3. Paging
            int totalRow = query.Count();

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
                            View = x.View == null ? 0 : x.View
                            
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

        public async Task<ApiResult<PagedResult<PostVm>>> GetPostPaging(GetUserPagingRequest request)
        {
            throw new NotImplementedException();
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
    }
}
