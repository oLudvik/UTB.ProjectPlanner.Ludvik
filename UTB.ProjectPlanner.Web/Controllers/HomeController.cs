using Microsoft.AspNetCore.Mvc;

namespace UTB.ProjectPlanner.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
