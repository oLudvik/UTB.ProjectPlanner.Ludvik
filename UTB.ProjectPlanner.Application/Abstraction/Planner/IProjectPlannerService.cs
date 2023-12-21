using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Application.ViewModels.Planner;

namespace UTB.ProjectPlanner.Application.Abstraction.Planner
{
    public interface IProjectPlannerService
    {
        List<ProjectProjectTaskViewModel> Index(int UserId);
    }
}
