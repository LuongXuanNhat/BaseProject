using BaseProject.ApiIntegration.Locations;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.AdminUI.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationApiClient _locationApiClient;

        public LocationController(
            ILocationApiClient locationApiClient)
        {
            _locationApiClient = locationApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {

            var request = new GetUserPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _locationApiClient.GetUsersPagings(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LocationCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _locationApiClient.RegisterOrUpdate(request);



            if (result.IsSuccessed != null && result.IsSuccessed == true)
            {
                TempData["result"] = "Thêm mới địa điểm thành công";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Thêm địa điểm thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _locationApiClient.GetById(id);
            if (result.IsSuccessed)
            {

                return View(result.ResultObj);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LocationCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _locationApiClient.RegisterOrUpdate(request);

            
            if (result.IsSuccessed != null)
            {
                TempData["result"] = "Cập nhập địa điểm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm địa điểm thất bại");
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            return View(new LocationCreateRequest()
            {
                LocationId = Id           
            });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(LocationCreateRequest request)
        {

            var result = await _locationApiClient.Delete(request.LocationId );
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa địa điểm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

    }
}
