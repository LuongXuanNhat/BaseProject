using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.Search;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ApiIntegration.Searchs
{
    public interface ISearchApiClient
    {
        //Task<ApiResult<PagedResult<CategoryRequest>>> GetUsersPagings(GetUserPagingRequest request);
        //Task<ApiResult<bool>> RegisterCategory(CategoryRequest request);

        //Task<ApiResult<bool>> UpdateCategory(int idCategory, CategoryRequest request);
        //Task<ApiResult<bool>> DeleteCategory(int idCategory);

        Task<ApiResult<SearchVm>> GetById(int id);
        Task<ApiResult<PagedResult<SearchVm>>> GetAllByUserName(GetUserPagingRequest request);
    }
}
