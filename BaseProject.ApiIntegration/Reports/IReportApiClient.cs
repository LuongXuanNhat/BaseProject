using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ApiIntegration.Reports
{
    public interface IReportApiClient
    {
        Task<ApiResult<PagedResult<Report>>> GetAll(GetUserPagingRequest request);
        Task<ApiResult<bool>> SendReport(Report request);
        Task<ApiResult<bool>> DeleteReport(int Id);
    }
}
