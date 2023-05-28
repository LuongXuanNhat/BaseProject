using BaseProject.ApiIntegration.Locations;
using BaseProject.ApiIntegration.RatingStars;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.WebApp.Controllers
{
    public class RatingsController : Controller
    {
        private readonly IRatingApiClient _ratingApiClient;
        public RatingsController(
            IRatingApiClient ratingApiClient)
        {
            _ratingApiClient = ratingApiClient;
        }
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetUserPagingRequest()
            {
                Keyword = User.Identity.Name,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _ratingApiClient.GetByUserName(request);
            //  ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }
    }
}
