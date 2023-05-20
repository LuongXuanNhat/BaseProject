using BaseProject.Application.Common;
using BaseProject.Data.EF;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.Catalog.Images
{
    public class ImagesService : IImageService
    {
        private readonly IStorageService _storageService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly DataContext _context;
        private const string USER_CONTENT_FOLDER_NAME = "Images";
        public ImagesService(IWebHostEnvironment webHostEnvironment, DataContext context, IStorageService storageService)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _storageService = storageService;
        }
        public async Task<ApiResult<bool>> SaveImage(List<IFormFile> image, Location location)
        {

            var ImageSave = new List<Image>();
            foreach (var item in image)
            {
                var GetImages = new Image()
                {
                    LocationId = location.LocationId,
                    FileName = item.FileName,
                    Path = await SaveFile(item)
                };
                ImageSave.Add(GetImages);
            }
            _context.Images.AddRangeAsync(ImageSave);
         //   _context.Locations.Update(location);
            await _context.SaveChangesAsync();


            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> UpdateImage(List<IFormFile> images, Location location)
        {
            var ImageSave = new List<Image>();
            var list_image = _context.Images.Where(x => x.LocationId == location.LocationId).ToList();

            for (int i = 0; i < list_image.Count; i++)
            {
                list_image[i].Path = list_image[i].Path.Remove(0,30);
                await _storageService.DeleteFileAsync(list_image[i].Path);
            }
            _context.Images.RemoveRange(list_image);

            foreach (var item in images)
            {
                var GetImages = new Image()
                {
                    LocationId = location.LocationId,
                    FileName = item.FileName,
                    Path = await SaveFile(item)
                };
                ImageSave.Add(GetImages);
            }
            _context.Images.AddRangeAsync(ImageSave);
            //   _context.Locations.Update(location);
            await _context.SaveChangesAsync();


            return new ApiSuccessResult<bool>();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "https://localhost:7204/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        
    }
}
