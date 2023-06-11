using Azure.Core;
using BaseProject.ApiIntegration.Reports;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Reports;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.WebApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportApiClient _reportApiClient;
        public ReportController(IReportApiClient reportApiClient)
        {
            _reportApiClient = reportApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SendReport([FromBody] ReportViewModel request)
        {
            var report = new Report();
            report.PostId = request.id;
            report.Date = DateTime.Now;
            report.UserId = new Guid();
            report.UserName = User.Identity.Name;
            if (request.comment != null && request.option != null)
            {
                string title = $"{User.Identity.Name} đã báo cáo 1 bài viết với nội dung: ";
                report.Content = title + request.option + " -" +" Chi tiết: " + request.comment;
            } else if (request.comment != null)
            {
                string title = $"{User.Identity.Name} đã báo cáo 1 bài  viết với nội dung";
                report.Content = title + " Chi tiết: " + request.comment;
            } else if (!string.IsNullOrEmpty(request.option))
            {
                string title = $"{User.Identity.Name} đã báo cáo 1 bài  viết với nội dung: ";
                report.Content = title + request.option;
            } else
            {
                return Ok();
            }

            var reponse = await _reportApiClient.SendReport(report);
            if (reponse.IsSuccessed)
            {
                return Json(new { success = true });
            }

            return BadRequest();
        }
    }
}
