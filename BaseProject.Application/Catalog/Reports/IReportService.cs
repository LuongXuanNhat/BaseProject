using BaseProject.Data.Entities;
using BaseProject.ViewModels.Common;
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
    }
}
