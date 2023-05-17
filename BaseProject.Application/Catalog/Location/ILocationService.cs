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
    public interface ILocationService
    {
        Task<ApiResult<bool>> Create(Location request);

        Task<ApiResult<bool>> Update(int id,Location request);

        Task<ApiResult<bool>> Delete(int categoryId);

        Task<ApiResult<PagedResult<Location>>> GetCategoryPaging(GetUserPagingRequest request);

        Task<ApiResult<Location>> GetById(int locationId);


    }
}
