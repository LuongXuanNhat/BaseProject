using BaseProject.Data.Entities;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ApiIntegration.Location
{
    public interface ILocationApiClient
    {
        Task<ApiResult<PagedResult<Data.Entities.Location>>> GetUsersPagings(GetUserPagingRequest request);
        Task<ApiResult<bool>> Register(Data.Entities.Location request);

        Task<ApiResult<bool>> Update(int idCategory, Data.Entities.Location request);
        Task<ApiResult<bool>> Delete(int idCategory);

        Task<ApiResult<Data.Entities.Location>> GetById(int id);



    }
}
