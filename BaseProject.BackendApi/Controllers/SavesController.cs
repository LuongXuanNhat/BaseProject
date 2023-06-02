using BaseProject.Application.Catalog.Locations;
using BaseProject.Application.Catalog.Saves;
using BaseProject.ViewModels.Catalog.Search;
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


        public SavesController(
            ILocationService locationService, ISaveService saveService)
        {
            _saveService = saveService;

        }


        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetUserPagingRequest request)
        {
            var rating = await _saveService.GetLocationPaging(request);
            return Ok(rating);
        }

        [HttpPost]
        public async Task<IActionResult> AddAddressToArchive(AddAddressSaveVm request)
        {
            var result = await _saveService.AddPlaces(request.Username, request.IdPlaces);
            if (result == true)
            {
                return Ok(request);
            }
            return BadRequest(request);
        }


    }
}
