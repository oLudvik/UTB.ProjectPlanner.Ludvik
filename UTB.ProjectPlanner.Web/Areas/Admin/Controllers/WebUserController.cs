using Microsoft.AspNetCore.Mvc;
using UTB.ProjectPlanner.Application.Abstraction.Admin;
using UTB.ProjectPlanner.Domain.Entities;

namespace UTB.ProjectPlanner.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WebUserController : Controller
    {
        IAdminWebUserService _adminWebUserService;
        public WebUserController(IAdminWebUserService adminWebUserService)
        {
            _adminWebUserService = adminWebUserService;
        }
        public IActionResult Index()
        {
            List<WebUser> users = _adminWebUserService.Index();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(WebUser user)
        {
            _adminWebUserService.Create(user);
            return RedirectToAction(nameof(WebUserController.Index));
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            return View(_adminWebUserService.Show(Id));
        }

        [HttpPost]
        public IActionResult Update(WebUser user)
        {
            _adminWebUserService.Update(user);
            return RedirectToAction(nameof(WebUserController.Index));
        }

        public IActionResult Delete(int id)
        {
            _adminWebUserService.Delete(id);
            return RedirectToAction(nameof(WebUserController.Index));
        }
    }
}
