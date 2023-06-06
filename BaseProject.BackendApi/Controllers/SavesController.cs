using Azure.Core;
using BaseProject.Application.Catalog.Locations;
using BaseProject.Application.Catalog.Saves;
using BaseProject.ViewModels.Catalog.FavoriteSave;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SavesController : ControllerBase
    {

        private readonly ISaveService _saveService;


        public SavesController(ISaveService saveService)
        {
            _saveService = saveService;

        }

        [HttpGet("check")]
        public async Task<IActionResult> Check([FromQuery] AddSaveVm request)
        {
            if (request.number == 1)
            {
                var result = await _saveService.Check(request.Username, request.Id, 1);
                if (result != null)
                {
                    return Ok();
                }
            } else if (request.number == 2)
            {
                var result = await _saveService.Check(request.Username, request.Id, 2);
                if (result != null)
                {
                    return Ok();
                }
            }
            
            return BadRequest();
            
        }


        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetUserPagingRequest request)
        {
            var result = await _saveService.GetLocationPaging(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAddressToArchive(AddSaveVm request)
        {
            if (request.number == 1)
            {
                var result = await _saveService.AddPlacesOrDelete(request.Username, request.Id);
                if (result != null)
                {
                    return Ok(result);
                }
            } else
            {
                var result = await _saveService.AddPostsOrDelete(request.Username, request.Id);
                if (result != null)
                {
                    return Ok(result);
                }
            }
           
            return BadRequest(request);
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var username = await _saveService.Delete(name);

            if (username == null)
            {
                return BadRequest();
            }
            return Ok();

        }
    }
}
