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

        public ProjectProjectTaskViewModel Show(int Id, int UserId)
        {
            Project p = _ProjectPlannerDbContext.Projects.First(p => p.Id == Id && p.UserId == UserId);
            IList<ProjectTask> pt = _ProjectPlannerDbContext.ProjectTasks.Where(ProjectTask => ProjectTask.ProjectId == p.Id).ToList();
            return new ProjectProjectTaskViewModel()
            {
                Project = p,
                ProjectTasks = pt
            };
        }
        public void Create(Project project, int UserId)
        {
            project.UserId = UserId;
            _ProjectPlannerDbContext.Projects.Add(project);
            _ProjectPlannerDbContext.SaveChanges();
        }
        public void Update(Project project, int UserId)
        {
            Project p = _ProjectPlannerDbContext.Projects.First(p => p.Id == project.Id);
            _ProjectPlannerDbContext.Projects.Remove(p);
            project.UserId = p.UserId;
            project.Id = p.Id;
            _ProjectPlannerDbContext.Projects.Add(project);
            _ProjectPlannerDbContext.SaveChanges();
        }
        public void Delete(int Id, int UserId)
        {
            Project p = _ProjectPlannerDbContext.Projects.First(p => p.Id == Id);
            IList<ProjectTask> pt = _ProjectPlannerDbContext.ProjectTasks.Where(ProjectTask => ProjectTask.ProjectId == p.Id).ToList();
            foreach (var task in pt)
            {
                _ProjectPlannerDbContext.ProjectTasks.Remove(task);
            }
            _ProjectPlannerDbContext.Projects.Remove(p);
            _ProjectPlannerDbContext.SaveChanges();
        }

        public Project get(int Id)
        {
            return _ProjectPlannerDbContext.Projects.First(p => p.Id == Id);
        }
    }
}
