using BaseProject.ApiIntegration;
using BaseProject.ApiIntegration.RatingStars;
using BaseProject.ApiIntegration.Searchs;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace BaseProject.WebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchApiClient _searchApiClient;
        private readonly BaseApiClient _baseApiClient;

        public SearchController(
            ISearchApiClient searchApiClient,
            BaseApiClient baseApiClient)
        {
            _searchApiClient = searchApiClient;
            _baseApiClient = baseApiClient;
        }
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 5)
        {

            ViewBag.Token = _baseApiClient.GetToken();
            ViewBag.Name = User.Identity.Name;
            var request = new GetUserPagingRequest()
            {
                Keyword = User.Identity.Name,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _searchApiClient.GetAllByUserName(request);

        //    ViewBag.Token = _baseApiClient.GetToken();

            return View(data.ResultObj);
        }
    }
}
