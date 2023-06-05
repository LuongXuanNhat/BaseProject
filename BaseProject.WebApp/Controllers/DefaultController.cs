using Microsoft.AspNetCore.Mvc;

namespace BaseProject.WebApp.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public DefaultController(IWebHostEnvironment env)
        {
            _env = env;
        }
        [HttpPost]
        public IActionResult UploadImage(List<IFormFile> files)
        {
            var filepath = "";
            foreach (IFormFile photo in Request.Form.Files) 
            {
                string serverMapPath = Path.Combine(_env.WebRootPath, "images", photo.FileName);
                using (var stream=new FileStream(serverMapPath, FileMode.Create))
                {
                    photo.CopyTo(stream);
                }
                filepath= "https://localhost:7202/" + "images/"+photo.FileName;
            }
            return Json(new { url = filepath });
        }
    }
}
