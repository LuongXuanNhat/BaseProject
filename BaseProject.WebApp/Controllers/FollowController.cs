using BaseProject.ApiIntegration.User;
using BaseProject.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.WebApp.Controllers
{
    [Authorize]
    public class FollowController : Controller
    {
        private readonly IUserApiClient _userApiClient;

        public FollowController(IUserApiClient userApiClient)
        {
            _userApiClient = userApiClient;

        }

        [HttpPost]
        public async Task<IActionResult> AddFollow([FromBody] Following following)
        {
            if (following == null)
            {
                return BadRequest();
            }
            var result = await _userApiClient.AddFollow(following);

            return View();
        }
    }
}
