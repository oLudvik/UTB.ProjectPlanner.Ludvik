using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTB.ProjectPlanner.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Identity;
using UTB.ProjectPlanner.Infrastructure.Identity;
using UTB.ProjectPlanner.Application.Abstraction.Planner;
using UTB.ProjectPlanner.Application.Implementation.Planner;
using UTB.ProjectPlanner.Application.ViewModels.Planner;


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
    }
}
