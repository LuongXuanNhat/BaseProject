using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.Catalog.Reports
{
    public interface IReportService
    {
        Task<ApiResult<bool>> Create(Report request);
        Task<ApiResult<PagedResult<Report>>> GetAll(GetUserPagingRequest request);

    }
}
