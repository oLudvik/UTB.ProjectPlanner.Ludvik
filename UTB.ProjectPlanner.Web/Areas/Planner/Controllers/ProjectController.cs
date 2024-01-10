using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTB.ProjectPlanner.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Identity;
using UTB.ProjectPlanner.Infrastructure.Identity;
using UTB.ProjectPlanner.Application.Abstraction.Planner;
using UTB.ProjectPlanner.Application.Implementation.Planner;
using UTB.ProjectPlanner.Application.ViewModels.Planner;
using UTB.ProjectPlanner.Domain.Entities;


namespace UTB.ProjectPlanner.Web.Areas.Planner.Controllers
{

    [Area("Planner")]
    [Authorize(Roles = nameof(Roles.Planner))]
    public class ProjectController : Controller
    {
        private readonly UserManager<User> _userManager;
        IProjectPlannerService _projectPlannerService;
        public ProjectController(UserManager<User> userManager, IProjectPlannerService projectPlannerService)
        {
            _userManager = userManager;
            _projectPlannerService = projectPlannerService;
        }
        public IActionResult Index()
        {
            List<ProjectProjectTaskViewModel> l = _projectPlannerService.Index(int.Parse(_userManager.GetUserId(User)) -1);
            return View(l);
        }

        public IActionResult Show(int id) {
            ProjectProjectTaskViewModel p = _projectPlannerService.Show(id, int.Parse(_userManager.GetUserId(User)) - 1);
            return View(p);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Project project)
        {
            _projectPlannerService.Create(project, int.Parse(_userManager.GetUserId(User)) - 1);
            return RedirectToAction(nameof(ProjectController.Index));
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            Project p = _projectPlannerService.get(Id);
            return View(p);
        }

        [HttpPost]
        public IActionResult Update(Project project)
        {
            _projectPlannerService.Update(project, int.Parse(_userManager.GetUserId(User)) - 1);
            return RedirectToAction(nameof(ProjectController.Index));
        }

        public IActionResult Delete(int id) {
            _projectPlannerService.Delete(id, int.Parse(_userManager.GetUserId(User)) - 1);
            return RedirectToAction(nameof(ProjectController.Index));
        }
    }
}
