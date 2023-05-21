using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<ApiResult<bool>> Create(CategoryRequest request);

        Task<ApiResult<bool>> Update(int id,CategoryRequest request);

        Task<ApiResult<bool>> Delete(int categoryId);

        Task<ApiResult<PagedResult<CategoryRequest>>> GetCategoryPaging(GetUserPagingRequest request);

        Task<ApiResult<CategoryRequest>> GetById(int categoryId);
        Task<ApiResult<List<Category>>> GetAll();

 
    }
}
