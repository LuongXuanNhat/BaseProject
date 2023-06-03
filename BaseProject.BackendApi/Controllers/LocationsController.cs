using BaseProject.Application.Catalog.Locations;
using BaseProject.Application.Catalog.Saves;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly ISaveService _saveService;


        public LocationsController(
            ILocationService locationService, ISaveService saveService)
        {
            _locationService = locationService;
            _saveService = saveService;
        }

        [Authorize]
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateOrUpdateLocation([FromForm] LocationCreateRequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var LocationId = await _locationService.CreateOrUpdate(request);
            if (!LocationId.IsSuccessed)
                return BadRequest(LocationId);

            return Ok(LocationId);
        }

        //Delete: http://localhost/api/categoriess/id
        [Authorize]
        [HttpDelete("{locationId}")]
        public async Task<IActionResult> DeleteLocation(int locationId)
        {
            var result = await _locationService.Delete(locationId);
            return Ok(result);
        }

        //http://localhost/api/location/paging?pageIndex=1&pageSize=10&keyword=
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetUserPagingRequest request)
        {
            var products = await _locationService.GetLocationPaging(request);
            return Ok(products);
        }

        // Get Places List by province
        //http://localhost/api/Location/pagingPlace?pageIndex=1&pageSize=10&keyword=...
        [HttpGet("pagingPlace")]
        public async Task<IActionResult> GetPlacesPaging([FromQuery] GetUserPagingRequest request)
        {
            var products = await _locationService.GetLocationPagingByKeys(request);
            return Ok(products);
        }

        //http://localhost/api/location/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _locationService.GetById(id);
            return Ok(user);
        }

        
        [HttpGet("show/{quantity}")]
        public async Task<IActionResult> TakeByQuantity(int quantity)
        {
            var user = await _locationService.TakeByQuantity(quantity);
            return Ok(user);
        }

        [HttpGet("detai/{idDetail}")]
        public async Task<IActionResult> GetByIdDetail(int idDetail)
        {
            var user = await _locationService.GetByIdDetail(idDetail);
            return Ok(user);
        }
    }
}
