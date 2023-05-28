using Azure.Core;
using BaseProject.Application.Catalog.Categories;
using BaseProject.Application.Catalog.Posts;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet("paging")]

        public async Task<IActionResult> GetAllPaging([FromQuery] GetUserPagingRequest request)
        {
            var rating = await _ratingService.GetByUserName(request);
            return Ok(rating);
        }

        [HttpPost]
        public async Task<IActionResult> Rating(string rating, string id)
        {
            if (rating == null || id == null)
            {
                return BadRequest();
            }

            int ratingValue = Convert.ToInt32(rating);
            int itemId = Convert.ToInt32(id);

            var result = await _ratingService.Rating(itemId , ratingValue);
            if (result == true)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
