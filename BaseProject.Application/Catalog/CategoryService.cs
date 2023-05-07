using BaseProject.Application.Common;
using BaseProject.Data.EF;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Common;
using Microsoft.AspNetCore.Identity;
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
            var category = await _context.Categories.FindAsync(request.Name);
            if (category != null)
            {
                return new ApiErrorResult<bool>("Danh mục đã tồn tại");
            }

            category = new Category()
            {
                Name = request.Name
            };
            _context.Categories.Add(category);
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
