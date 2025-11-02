using Microsoft.AspNetCore.Mvc;

namespace site_da_escola.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
