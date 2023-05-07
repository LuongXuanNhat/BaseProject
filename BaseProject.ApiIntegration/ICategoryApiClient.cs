using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ApiIntegration
{
    public interface ICategoryApiClient
    {
        Task<ApiResult<PagedResult<CategoryRequest>>> GetUsersPagings(GetUserPagingRequest request);
        Task<ApiResult<bool>> RegisterCategory(CategoryRequest request);

        Task<ApiResult<bool>> UpdateCategory(CategoryRequest request);
        Task<ApiResult<bool>> DeleteCategory(CategoryDeleteRequest request);

        Task<ApiResult<CategoryRequest>> GetById(int id);

        

    }
}
