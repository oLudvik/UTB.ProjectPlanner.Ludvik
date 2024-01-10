using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UTB.ProjectPlanner.Domain.Entities;
using UTB.ProjectPlanner.Infrastructure.Identity;
using UTB.ProjectPlanner.Infrastructure.Identity.Enums;
using UTB.ProjectPlanner.Web.Areas.Planner.Controllers;

namespace UTB.ProjectPlanner.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateUser(User user)
        {
            return RedirectToAction(nameof(AdminController.Index));
        }
        public IActionResult DeleteUser(int id)
        {
            return RedirectToAction(nameof(AdminController.Index));
        }


        [HttpGet]
        public IActionResult UpdateProject()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateProject(Project project)
        {
            return RedirectToAction(nameof(AdminController.Index));
        }
        public IActionResult DeleteProject(int id)
        {
            return RedirectToAction(nameof(AdminController.Index));
        }


        [HttpGet]
        public IActionResult UpdateTask()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateTask(ProjectTask task)
        {
            return RedirectToAction(nameof(AdminController.Index));
        }
        public IActionResult DeleteTask(int id)
        {
            return RedirectToAction(nameof(AdminController.Index));
        }
    }
}
