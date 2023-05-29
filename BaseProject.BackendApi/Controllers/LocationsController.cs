using BaseProject.Application.Catalog.Categories;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;


        public LocationsController(
            ILocationService locationService)
        {
            _locationService = locationService;
        }


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

        //PUT: http://localhost/api/categoriess/id
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateLocation(int id, [FromBody] LocationCreateRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var result = await _locationService.Update(id, request);
        //    if (!result.IsSuccessed)
        //    {
        //        return BadRequest(result);
        //    }
        //    return Ok(result);
        //}

        //Delete: http://localhost/api/categoriess/id
        [HttpDelete("{locationId}")]
        public async Task<IActionResult> DeleteLocation(int locationId)
        {
            var result = await _locationService.Delete(locationId);
            return Ok(result);
        }

        //http://localhost/api/categoriess/paging?pageIndex=1&pageSize=10&keyword=
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetUserPagingRequest request)
        {
            var products = await _locationService.GetLocationPaging(request);
            return Ok(products);
        }

        // Get Places List by province
        //http://localhost/api/Location/pagingPlace?pageIndex=1&pageSize=10&keyword=@province=
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

        [HttpGet("detai/{idDetail}")]
        public async Task<IActionResult> GetByIdDetail(int idDetail)
        {
            var user = await _locationService.GetByIdDetail(idDetail);
            return Ok(user);
        }
    }
}
