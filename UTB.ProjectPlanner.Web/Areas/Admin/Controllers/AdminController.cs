using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UTB.ProjectPlanner.Application.Abstraction.Admin;
using UTB.ProjectPlanner.Application.ViewModels.Admin;
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
        IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            IList<EverythingViewModel> evm = _adminService.Index();
            return View(evm);
        }

        [HttpGet]
        public IActionResult UpdateUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateUser(User user)
        {
            _adminService.UpdateUser(user);
            return RedirectToAction(nameof(AdminController.Index));
        }
        public IActionResult DeleteUser(int id)
        {
            _adminService.DeleteUser(id);
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
            _adminService.UpdateProject(project);
            return RedirectToAction(nameof(AdminController.Index));
        }
        public IActionResult DeleteProject(int id)
        {
            _adminService.DeleteProject(id);
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
            _adminService.UpdateTask(task);
            return RedirectToAction(nameof(AdminController.Index));
        }
        public IActionResult DeleteTask(int id)
        {
            _adminService.DeleteTask(id);
            return RedirectToAction(nameof(AdminController.Index));
        }
    }
}
