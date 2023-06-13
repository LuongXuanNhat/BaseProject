using BaseProject.Application.Catalog.Categories;
using BaseProject.Application.Catalog.Notifications;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;


        public NotificationsController(
            INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("getall/{userName}")]
        public async Task<IActionResult> GetAll(string userName)
        {
            var result = await _notificationService.GetAll(userName);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetUserPagingRequest request)
        {
            var products = await _notificationService.GetNotificationPaging(request);
            return Ok(products);
        }
    }
}
