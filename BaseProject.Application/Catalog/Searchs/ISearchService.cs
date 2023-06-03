using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.Catalog.RatingStar;
using BaseProject.ViewModels.Catalog.Search;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.Catalog.Searchs
{
    public interface ISearchService
    {
        
        Task<ApiResult<bool>> Delete(string usename);
        Task<ApiResult<bool>> Add(Guid UserId, List<String> Content);

        Task<ApiResult<PagedResult<SearchVm>>> GetAllSearchHistoryPaging(GetUserPagingRequest request);




    }
}
