using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Application.Abstraction.Planner;
using UTB.ProjectPlanner.Application.ViewModels.Planner;
using UTB.ProjectPlanner.Domain.Entities;
using UTB.ProjectPlanner.Infrastructure.Database;

namespace UTB.ProjectPlanner.Application.Implementation.Planner
{
    public class ProjectPlannerService : IProjectPlannerService
    {
        ProjectPlannerDbContext _ProjectPlannerDbContext;
        public ProjectPlannerService(ProjectPlannerDbContext projectPlannerDbContext)
        {
            _ProjectPlannerDbContext = projectPlannerDbContext;
        }
        public List<ProjectProjectTaskViewModel> Index(int UserId)
        {
            IList<Project> userProjects = _ProjectPlannerDbContext.Projects.Where(Project => Project.UserId == UserId).ToList();
            List<ProjectProjectTaskViewModel> retval = new List<ProjectProjectTaskViewModel>();
            if (userProjects.Count > 0)
            {
                foreach (Project project in userProjects)
                {
                    retval.Add(new ProjectProjectTaskViewModel()
                    {
                        Project = project,
                        ProjectTasks = _ProjectPlannerDbContext.ProjectTasks.Where(ProjectTask => ProjectTask.ProjectId == project.Id).ToList()
                    }) ;
                }
            }
            return retval;
        }
    }
}
