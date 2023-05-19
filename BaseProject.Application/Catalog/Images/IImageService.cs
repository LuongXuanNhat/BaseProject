using BaseProject.ViewModels.Common;
using System;
using BaseProject.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BaseProject.Application.Catalog.Images
{
    public interface IImageService
    {
        Task<ApiResult<bool>> SaveImage(List<IFormFile> images, Location location);
        Task<ApiResult<bool>> UpdateImage(List<IFormFile> images, Location location);
        
    }
}
