using Microsoft.AspNetCore.Mvc;

namespace site_da_escola.Controllers
{
    public class SobreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
