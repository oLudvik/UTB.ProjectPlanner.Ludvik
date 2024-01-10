using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Application.ViewModels.Planner;
using UTB.ProjectPlanner.Domain.Entities;

namespace UTB.ProjectPlanner.Application.Abstraction.Planner
{
    public interface IProjectPlannerService
    {
        List<ProjectProjectTaskViewModel> Index(int UserId);
        ProjectProjectTaskViewModel Show(int Id, int UserId);
        void Create(Project project, int UserId);
        void Update(Project project, int UserId);
        void Delete(int Id, int UserId);
        Project get(int Id);
    }
}
