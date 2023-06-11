using BaseProject.ApiIntegration.Category;
using BaseProject.ApiIntegration.Reports;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.AdminUI.Controllers
{
    public class ReportController : Controller
    {
        //private readonly IConfiguration _configuration;
        private readonly IReportApiClient _reportApiClient;

        public ReportController(
            IReportApiClient reportApiClient)
        {
            //_configuration = configuration;
            _reportApiClient = reportApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {

            var request = new GetUserPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _reportApiClient.GetAll(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }
    }
}
