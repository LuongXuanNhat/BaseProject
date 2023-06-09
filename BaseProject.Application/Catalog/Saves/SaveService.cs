﻿using Azure.Core;
using BaseProject.Application.Catalog.Categories;
using BaseProject.Application.Catalog.Images;
using BaseProject.Application.Common;
using BaseProject.Application.System.Users;
using BaseProject.Data.EF;
using BaseProject.Data.Entities;
using BaseProject.Data.Enums;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.FavoriteSave;
using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Catalog.RatingStar;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BaseProject.Application.Catalog.Saves
{
    public class SaveService : ISaveService
    {

        private readonly DataContext _context;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;


        public SaveService(DataContext context, IUserService userService, ICategoryService categoryService)
        {
            _context = context;
            _userService = userService;
            _categoryService = categoryService; 
        }

        public async Task<Saved> Check(string UserName, int Id,int number)
        {
            var UserId = await _userService.GetIdByUserName(UserName);
            var check = await _context.Saveds.FirstOrDefaultAsync(x => x.LocationId == Id && x.UserId == UserId);
            if (number == 1)
            {
                 check = await _context.Saveds.FirstOrDefaultAsync(x => x.LocationId == Id && x.UserId == UserId);
            } else
            if (number == 2)
            {
                check = await _context.Saveds.FirstOrDefaultAsync(x => x.PostId == Id && x.UserId == UserId);
            }

            return check;
        }

        // Lưu địa điểm vào danh mục yêu thích
        // Xóa địa điểm khỏi danh mục yêu thích
        public async Task<ApiResult<bool>> AddPlacesOrDelete(string UserName, int PlacesId)
        {
            var UserId = await _userService.GetIdByUserName(UserName);
            var check = await Check(UserName, PlacesId, 1);
            if (check != null)
            {
                _context.Saveds.Remove(check);
                await _context.SaveChangesAsync();
                return new ApiErrorResult<bool> ("Đã xóa địa điểm khỏi danh sách yêu thích");
            }
            else
            {
                var item = new Saved()
                {
                    PostId = null,
                    UserId = UserId,
                    LocationId = PlacesId,
                    Date = DateTime.UtcNow
                };
                _context.Saveds.Add(item);
                await _context.SaveChangesAsync();
                return new ApiErrorResult<bool>("Đã thêm địa điểm vào danh sách yêu thích");
            }
        }


        public async Task<ApiResult<bool>> AddPostsOrDelete(string UserName, int PostId)
        {
            var UserId = await _userService.GetIdByUserName(UserName);
            var check = await Check(UserName, PostId, 2);
            if (check != null)
            {
                _context.Saveds.Remove(check);
                await _context.SaveChangesAsync();
                return new ApiErrorResult<bool> ("Đã xóa bài viết khỏi danh sách yêu thích");
            }
            else
            {
                var item = new Saved()
                {
                    PostId = PostId,
                    UserId = UserId,
                    LocationId = null,
                    Date = DateTime.UtcNow
                };
                _context.Saveds.Add(item);
                await _context.SaveChangesAsync();
                return new ApiErrorResult<bool>("Đã thêm bài viết vào danh sách yêu thích");
            }
        }
        public int CountById(Guid Id, int PostId)
        {
            return _context.Saveds.Where(x=>x.UserId == Id && x.PostId == PostId).Count();
        }

        public async Task<ApiResult<PagedResult<LocationVm>>> GetLocationPaging(GetUserPagingRequest request)
        {
            var UserId = await _userService.GetIdByUserName(request.UserName);

            var getLocationId = await _context.Saveds.OrderByDescending(x => x.Date).Where(x=>x.UserId == UserId && x.LocationId != 0).Select(x=>x.LocationId).ToListAsync();
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
            var UserId = await _userService.GetIdByUserName(request.UserName);

            var getPostId = await _context.Saveds.OrderByDescending(x => x.Date).Where(x => x.UserId == UserId && x.PostId != 0).Select(x => x.PostId).ToListAsync();
            var query = await _context.Posts.Where(x => getPostId.Contains(x.PostId)).ToListAsync();
            var list_content = await _context.LocationsDetails.ToListAsync();
            var filteredList = list_content.Where(content => query.Any(post => post.PostId == content.PostId)).ToList();
            var list_category = await _categoryService.GetAllCategoryDetail();

            //3. Paging
            int totalRow = query.Count();

            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new PostVm()
                {
                    PostId = x.PostId,
                    Content = filteredList.FirstOrDefault(y => y.PostId == x.PostId).Content,
                    Categories = list_category.Where(y => y.PostId == x.PostId).Select(x => x.Description).ToList(),
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

        public async Task<ApiResult<bool>> Delete(string usename, int number)
        {
            var UserId = await _userService.GetIdByUserName(usename);

            if (number == 1)
            {
                var query = await _context.Saveds.Where(x => x.UserId == UserId && x.LocationId != null).ToListAsync();
                _context.Saveds.RemoveRange(query);
            } else if(number == 2){
                var query = await _context.Saveds.Where(x => x.UserId == UserId && x.PostId != null).ToListAsync();
                _context.Saveds.RemoveRange(query);
            }
            
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }
    }
}
