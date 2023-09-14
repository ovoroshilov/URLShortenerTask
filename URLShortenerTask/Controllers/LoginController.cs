using Microsoft.AspNetCore.Mvc;

namespace URLShortenerTask.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
