using Microsoft.AspNetCore.Mvc;

namespace Gemini.Web.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            ViewBag.Title = "首页";
            return View();
        }

        public IActionResult Error() {
            return View();
        }
    }
}