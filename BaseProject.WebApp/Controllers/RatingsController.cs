using BaseProject.ApiIntegration;
using BaseProject.ApiIntegration.Locations;
using BaseProject.ApiIntegration.RatingStars;
using BaseProject.BackendApi.Utilities.Constants;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.WebApp.Controllers
{
    public class RatingsController : Controller
    {
        private readonly IRatingApiClient _ratingApiClient;
        private readonly BaseApiClient _baseApiClient;

        public RatingsController(
            IRatingApiClient ratingApiClient,
            BaseApiClient baseApiClient)
        {
            _ratingApiClient = ratingApiClient;
            _baseApiClient = baseApiClient;
        }
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetUserPagingRequest()
            {
                Keyword = User.Identity.Name,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _ratingApiClient.GetByUserName(request);

            ViewBag.Token = _baseApiClient.GetToken();

            return View(data.ResultObj);
        }
    }
}
