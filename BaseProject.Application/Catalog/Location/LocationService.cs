using Azure.Core;
using BaseProject.Application.Common;
using BaseProject.Data.EF;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.Catalog.Categories
{
    public class LocationService : ILocationService
    {

        private readonly DataContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "Images";

        public LocationService(DataContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> Create(Location request)
        {
            Location location = await _context.Locations.FirstOrDefaultAsync(x => x.Address == request.Address);

            if (location != null)
            {
                return new ApiErrorResult<bool>("Địa điểm đã tồn tại");
            }
 
            _context.Locations.Add(request);
            _context.SaveChanges();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Update(int id, Location request)
        {
            if (id == null)
            {
                return new ApiErrorResult<bool>("Lỗi cập nhập");
            }

            _context.Locations.Update(request);
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

        public async Task<ApiResult<PagedResult<Location>>> GetCategoryPaging(GetUserPagingRequest request)
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
                .Select(x => new Location()
                {
                    LocationId = x.LocationId,
                    Name = x.Name,
                    Address = x.Address
                }).ToList();

            //4. Select and projection
            var pagedResult = new PagedResult<Location>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<Location>>(pagedResult);
        }

        public async Task<ApiResult<Location>> GetById(int locationId)
        {
            var location = await _context.Locations.Where(x => x.LocationId == locationId).FirstOrDefaultAsync();
            if (location == null)
            {
                return new ApiErrorResult<Location>("Địa điểm không tồn tại");
            }

            return new ApiSuccessResult<Location>(location);
        }
    }
}
