using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.Catalog
{
    public interface ICategoryService
    {
        Task<ApiResult<bool>> Create(CategoryRequest request);

        Task<ApiResult<bool>> Update(CategoryRequest request);

        Task<ApiResult<bool>> Delete(int categoryId);

            //Task<ProductVm> GetById(int productId, string languageId);

            //Task<bool> UpdatePrice(int productId, decimal newPrice);

            //Task<bool> UpdateStock(int productId, int addedQuantity);

            //Task AddViewcount(int productId);

            //Task<PagedResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request);

            //Task<int> AddImage(int productId, ProductImageCreateRequest request);

            //Task<int> RemoveImage(int imageId);

            //Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);

            //Task<ProductImageViewModel> GetImageById(int imageId);

            //Task<List<ProductImageViewModel>> GetListImages(int productId);
    }
}
