using BaseProject.ApiIntegration;
using BaseProject.ApiIntegration.Nofications;
using BaseProject.ApiIntegration.RatingStars;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.WebApp.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INoficationApiClient _notiApiClient;
        private readonly BaseApiClient _baseApiClient;

        public NotificationController(
            INoficationApiClient notiApiClient,
            BaseApiClient baseApiClient)
        {
            _notiApiClient = notiApiClient;
            _baseApiClient = baseApiClient;
        }

        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetUserPagingRequest()
            {
                Keyword = User.Identity.Name,
                PageIndex = pageIndex,
                PageSize = pageSize,
                
            };
            var Notification = await _notiApiClient.GetUsersPagings(request);

            return View(Notification.ResultObj);
        }

    }
}
