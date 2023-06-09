using BaseProject.Data.Entities;
using BaseProject.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ApiIntegration.Reports
{
    public interface IReportApiClient
    {
        Task<ApiResult<bool>> SendReport(Report request);
        Task<ApiResult<bool>> DeleteReport(int Id);
    }
}
