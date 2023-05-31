using BaseProject.Application.Catalog.Searchs;
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
    [Authorize]
    public class SearchsController : ControllerBase
    {
        private readonly ISearchService _searchService;


        public SearchsController(
            ISearchService searchService)
        {
            _searchService = searchService;
        }


        //http://localhost/api/searchs/history/paging?pageIndex=1&pageSize=10&keyword=
        [HttpGet("history/paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetUserPagingRequest request)
        {
            var products = await _searchService.GetAllSearchHistoryPaging(request);
            return Ok(products);
        }


        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var username = await _searchService.Delete(name);

            if (username == null)
            {
                return BadRequest();
            }
            return Ok();

        }
    }
}
