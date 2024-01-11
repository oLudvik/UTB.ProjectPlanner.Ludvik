using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Application.Abstraction.Planner;
using UTB.ProjectPlanner.Domain.Entities;
using UTB.ProjectPlanner.Infrastructure.Database;

namespace UTB.ProjectPlanner.Application.Implementation.Planner
{
    public class ProjectTaskService : IProjectTaskService
    {
        ProjectPlannerDbContext _ProjectPlannerDbContext;
        public ProjectTaskService(ProjectPlannerDbContext projectPlannerDbContext)
        {
            _ProjectPlannerDbContext = projectPlannerDbContext;
        }
        public ProjectTask Show(int Id, int UserId)
        {
            return _ProjectPlannerDbContext.ProjectTasks.First(pt => pt.Id == Id);
        }
        public void Create(ProjectTask projectTask, int UserId)
        {
            List<ProjectTask> pt = _ProjectPlannerDbContext.ProjectTasks.OrderByDescending(pt => pt.Id).ToList();
            int xddId;
            if(pt.Count > 0)
            {
                xddId = pt[0].Id + 1;
            } else
            {
                xddId = 0;
            }
            projectTask.Id = xddId;
            _ProjectPlannerDbContext.ProjectTasks.Add(projectTask);
            _ProjectPlannerDbContext.SaveChanges();
        }
        public void Update(ProjectTask projectTask, int UserId)
        {
            ProjectTask p = _ProjectPlannerDbContext.ProjectTasks.First(p => p.Id == projectTask.Id);
            _ProjectPlannerDbContext.ProjectTasks.Remove(p);
            projectTask.ProjectId = p.ProjectId;
            projectTask.Id = p.Id;
            _ProjectPlannerDbContext.ProjectTasks.Add(projectTask);
            _ProjectPlannerDbContext.SaveChanges();
        }
        public void Delete(int Id, int UserId)
        {
            _ProjectPlannerDbContext.ProjectTasks.Remove(_ProjectPlannerDbContext.ProjectTasks.First(p => p.Id == Id));
            _ProjectPlannerDbContext.SaveChanges();
        }

        public ProjectTask Get(int Id)
        {
            return _ProjectPlannerDbContext.ProjectTasks.First(p => p.Id == Id);
        }

        public Project GetProject(int Id)
        {
            return _ProjectPlannerDbContext.Projects.First(p => p.Id == Id);
        }
    }
}
