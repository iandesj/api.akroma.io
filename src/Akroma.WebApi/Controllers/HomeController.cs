using Microsoft.AspNetCore.Mvc;

namespace Akroma.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("");
        }
    }
}
