using BaseProject.Application.Common;
using BaseProject.Data.EF;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Common;
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

        public async Task<ApiResult<bool>> Update(CategoryRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<bool>> Delete(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
