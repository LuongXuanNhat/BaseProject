using BaseProject.ApiIntegration;
using BaseProject.ApiIntegration.Category;
using BaseProject.ApiIntegration.Locations;
using BaseProject.ApiIntegration.Post;
using BaseProject.ApiIntegration.Saves;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.AdminUI.Controllers
{
    public class PostsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IPostApiClient _postApiClient;
        private readonly ILocationApiClient _locationApiClient;
        private readonly ICategoryApiClient _cateApiClient;
        private readonly BaseApiClient _baseApiClient;
        private readonly ISaveApiClient _saveApiClient;
        public PostsController(IConfiguration configuration,
            IPostApiClient postApiClient, ICategoryApiClient cateApiClient,
            BaseApiClient baseApiClient, ILocationApiClient locationApiClient,
            ISaveApiClient saveApiClient)
        {
            _configuration = configuration;
            _postApiClient = postApiClient;
            _cateApiClient = cateApiClient;
            _baseApiClient = baseApiClient;
            _locationApiClient = locationApiClient;
            _saveApiClient = saveApiClient;


        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {

            var request = new GetUserPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                UserName = null,
                number = 4,
                Keyword2 = keyword
            };
            var data = await _postApiClient.GetAllPostPagings(request);
            ViewBag.Keyword = keyword;
            ViewBag.Token = _baseApiClient.GetToken();
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }
    }
}
