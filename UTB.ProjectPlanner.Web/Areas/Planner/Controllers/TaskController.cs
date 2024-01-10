using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UTB.ProjectPlanner.Application.Abstraction.Planner;
using UTB.ProjectPlanner.Application.Implementation.Planner;
using UTB.ProjectPlanner.Domain.Entities;
using UTB.ProjectPlanner.Infrastructure.Identity;
using UTB.ProjectPlanner.Infrastructure.Identity.Enums;
using UTB.ProjectPlanner.Web.Controllers;

namespace UTB.ProjectPlanner.Web.Areas.Planner.Controllers
{
    [Area("Planner")]
    [Authorize(Roles = nameof(Roles.Planner))]
    public class TaskController : Controller
    {
        private readonly UserManager<User> _userManager;
        IProjectTaskService _projectTaskService;
        public TaskController(UserManager<User> userManager, IProjectTaskService projectTaskService)
        {
            _userManager = userManager;
            _projectTaskService = projectTaskService;
        }
        public IActionResult Show(int id)
        {
            ProjectTask p = _projectTaskService.Show(id, int.Parse(_userManager.GetUserId(User)) - 1);
            return View(p);
        }

        [HttpGet]
        public IActionResult Create(int Id)
        {
            ProjectTask npt = new ProjectTask() { ProjectId = Id };
            return View(npt);
        }

        [HttpPost]
        public IActionResult Create(ProjectTask pt, int ProjectId)
        {
            _projectTaskService.Create(pt, int.Parse(_userManager.GetUserId(User)) - 1);
            return RedirectToAction(nameof(TaskController.Show), new {Id = pt.Id});
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            ProjectTask pt = _projectTaskService.Get(Id);
            return View(pt);
        }

        [HttpPost]
        public IActionResult Update(ProjectTask pt)
        {
            _projectTaskService.Update(pt, int.Parse(_userManager.GetUserId(User)) - 1);
            return RedirectToAction(nameof(TaskController.Show), new { Id = pt.Id });
        }

        public IActionResult Delete(int id)
        {
            int pId = _projectTaskService.Get(id).ProjectId;
            _projectTaskService.Delete(id, int.Parse(_userManager.GetUserId(User)) - 1);
            return RedirectToAction(nameof(ProjectController.Show), nameof(ProjectController).Replace(nameof(Controller), String.Empty), new { id = pId });
        }
    }
}
