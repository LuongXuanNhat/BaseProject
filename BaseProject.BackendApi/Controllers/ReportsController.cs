using BaseProject.Application.Catalog.Categories;
using BaseProject.Application.Catalog.Reports;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;


        public ReportsController(
            IReportService reportService)
        {
            _reportService = reportService ;
        }

        [HttpPost]
        public async Task<IActionResult> Create( Report request)
        {
            var result = await _reportService.Create(request);
            if (!result.IsSuccessed)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
