using Azure.Core;
using BaseProject.Application.Catalog.Images;
using BaseProject.Application.Common;
using BaseProject.Data.EF;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.Location;
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
            Location location = await _context.Locations.FirstOrDefaultAsync(x => x.Address == request.Address);

            if (location != null)
            {
                if (request.LocationId != 0)
                {
                    if (request.Name == location.Name && request.Address == location.Address )
                    {

                    } else
                    {
                        var place = new Location()
                        {
                            LocationId = request.LocationId,
                            Name = request.Name,
                            Address = request.Address

                        };
                        _context.Locations.Update(place);
                    }     
                    if (request.GetImage != null && request.GetImage.Count != 0)
                    {
                        var saveImagePlace = await _imageService.UpdateImage(request.GetImage, location);
                        if (saveImagePlace != null && saveImagePlace.IsSuccessed == true)
                        {
                            _context.SaveChanges();
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
                Location findID = await _context.Locations.FirstOrDefaultAsync(x => x.Address == request.Address);
                var saveImage = await _imageService.SaveImage(request.GetImage, findID);

                if (saveImage != null && saveImage.IsSuccessed == true)
                {
                    return new ApiSuccessResult<bool>();
                }
                return new ApiErrorResult<bool>("Lỗi lưu ảnh");
            }


            return new ApiErrorResult<bool>();
        }

        public async Task<ApiResult<bool>> Update(int id, LocationCreateRequest request)
        {
            if (id == null)
            {
                return new ApiErrorResult<bool>("Lỗi cập nhập");
            }

         //   _context.Locations.Update(request);
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
