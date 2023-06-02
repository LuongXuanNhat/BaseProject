using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Catalog.Search;
using BaseProject.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ApiIntegration.Saves
{
    public interface ISaveApiClient
    {
        Task<ApiResult<bool>> AddAddressToArchive(AddAddressSaveVm request);
    }
}
