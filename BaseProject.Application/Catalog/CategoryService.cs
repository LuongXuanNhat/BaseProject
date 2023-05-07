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

namespace BaseProject.Application.Catalog
{
    public class CategoryService : ICategoryService
    {

        private readonly DataContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "Images";

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> Create(CategoryRequest request)
        {
            if (request.Name == null)
            {
                return new ApiErrorResult<bool>("Tên danh mục trống");
            }
            List<Category> category = await _context.Categories.Where(x => x.Name == request.Name).ToListAsync();


            if (category.Count != 0)
            {
                return new ApiErrorResult<bool>("danh mục đã tồn tại");
            }
            
            var category1 = new Category()
            {
                Name = request.Name
            };
            _context.Categories.Add(category1);
            _context.SaveChanges();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Update(int id,CategoryRequest request)
        {
            if (id == null)
            {
                return new ApiErrorResult<bool>("Lỗi cập nhập");
            }
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoriesId == id);

            category.Name = request.Name;
           
            _context.Categories.Update(category);
            _context.SaveChanges();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Delete(int categoryId)
        {
            if (categoryId == null)
            {
                return new ApiErrorResult<bool>("Lỗi cập nhập");
            }
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoriesId == categoryId);

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<PagedResult<CategoryRequest>>> GetCategoryPaging(GetUserPagingRequest request)
        {
            var query = await _context.Categories.ToListAsync();
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query =  query.Where(x => x.Name.Contains(request.Keyword)).ToList();
            }

            //3. Paging
            int totalRow =  query.Count();

            var data =  query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new CategoryRequest()
                {
                    CategoriesId = x.CategoriesId,
                    Name = x.Name
                }).ToList();

            //4. Select and projection
            var pagedResult = new PagedResult<CategoryRequest>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<CategoryRequest>>(pagedResult);
        }

        public async Task<ApiResult<CategoryRequest>> GetById(int categoryId)
        {
            var cate = await _context.Categories.Where(x=> x.CategoriesId == categoryId).FirstOrDefaultAsync();
            if (cate == null)
            {
                return new ApiErrorResult<CategoryRequest>("Danh mục không tồn tại");
            }

            var category = new CategoryRequest()
            {
                CategoriesId = cate.CategoriesId,
                Name = cate.Name                
            };
            return new ApiSuccessResult<CategoryRequest>(category);
        }
    }
}
