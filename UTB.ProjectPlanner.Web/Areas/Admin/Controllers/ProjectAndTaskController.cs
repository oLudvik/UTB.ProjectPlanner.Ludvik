using Microsoft.AspNetCore.Mvc;
using UTB.ProjectPlanner.Application.Abstraction.Admin;
using UTB.ProjectPlanner.Application.ViewModels.Admin;
using UTB.ProjectPlanner.Domain.Entities;

namespace UTB.ProjectPlanner.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectAndTaskController : Controller
    {
        IAdminWebUserService _adminWebUserService;
        public ProjectAndTaskController(IAdminWebUserService adminWebUserService)
        {
            _adminWebUserService = adminWebUserService;
        }
        public IActionResult Index()
        {
            List<ProjectAndTaskViewModel> projectAndTaskViewModels = _adminWebUserService.GetProjectAndTasksViewModel();
            return View(projectAndTaskViewModels);
        }
        public IActionResult Show(int Id)
        {
            Console.WriteLine(Id);
            List<ProjectAndTaskViewModel> projectAndTaskViewModels = _adminWebUserService.ShowUsersProjectsAndTasks(Id);
            return View(projectAndTaskViewModels);
        }

        [HttpGet]
        public IActionResult CreateProject()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProject(Project project)
        {
            _adminWebUserService.CreateProject(project);
            return RedirectToAction(nameof(ProjectAndTaskController.Index));
        }

        [HttpGet]
        public IActionResult UpdateProject(int Id)
        {
            return View(_adminWebUserService.ShowProject(Id));
        }

        [HttpPost]
        public IActionResult UpdateProject(Project project)
        {
            _adminWebUserService.UpdateProject(project);
            return RedirectToAction(nameof(ProjectAndTaskController.Index));
        }

        public IActionResult DeleteProject(int Id)
        {
            _adminWebUserService.DeleteProject(Id);
            return RedirectToAction(nameof(ProjectAndTaskController.Index));
        }

        [HttpGet]
        public IActionResult CreateTask()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateTask(ProjectTask task)
        {
            _adminWebUserService.CreateTask(task);
            return RedirectToAction(nameof(ProjectAndTaskController.Index));
        }

        [HttpGet]
        public IActionResult UpdateTask(int Id)
        {
            return View(_adminWebUserService.ShowTask(Id));
        }

        [HttpPost]
        public IActionResult UpdateTask(ProjectTask task)
        {
            _adminWebUserService.UpdateTask(task);
            return RedirectToAction(nameof(ProjectAndTaskController.Index));
        }

        public IActionResult DeleteTask(int Id)
        {
            _adminWebUserService.DeleteTask(Id);
            return RedirectToAction(nameof(ProjectAndTaskController.Index));
        }
    }
}
