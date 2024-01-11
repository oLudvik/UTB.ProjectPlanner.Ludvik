using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Application.Abstraction.Admin;
using UTB.ProjectPlanner.Application.ViewModels.Admin;
using UTB.ProjectPlanner.Domain.Entities;
using UTB.ProjectPlanner.Infrastructure.Database;
using UTB.ProjectPlanner.Infrastructure.Identity;

namespace UTB.ProjectPlanner.Application.Implementation.Admin
{
    public class AdminService : IAdminService
    {
        ProjectPlannerDbContext _ProjectPlannerDbContext;
        public AdminService(ProjectPlannerDbContext projectPlannerDbContext)
        {
            _ProjectPlannerDbContext = projectPlannerDbContext;
        }
        public IList<EverythingViewModel> Index()
        {
            IList<EverythingViewModel> retval = new List<EverythingViewModel>();
            IList<User> usr = _ProjectPlannerDbContext.Users.ToList();
            foreach (User user in usr) {
                
                IList<ProjectAndTasks> retval2 = new List<ProjectAndTasks>();
                IList<Project> proj = _ProjectPlannerDbContext.Projects.Where(p => p.UserId == user.Id).ToList();
                foreach (Project p in proj)
                {
                    retval2.Add(new ProjectAndTasks()
                    {
                        Project = p,
                        Tasks = _ProjectPlannerDbContext.ProjectTasks.Where(pt => pt.ProjectId == p.Id).ToList(),
                    });
                }
                retval.Add(new EverythingViewModel()
                {
                    User = user,
                    ProjectAndTasks = retval2,
                });
            }
            return retval;
        }
        public void UpdateUser(User user)
        {
            User u = _ProjectPlannerDbContext.Users.First(u => u.Id == user.Id);
            _ProjectPlannerDbContext.Users.Remove(u);
            user.Id = u.Id;
            _ProjectPlannerDbContext.Users.Add(user);
            _ProjectPlannerDbContext.SaveChanges();
        }

        public void DeleteUser(int Id)
        {
            User user = _ProjectPlannerDbContext.Users.First(u => u.Id == Id);
            IList<Project> projects = _ProjectPlannerDbContext.Projects.Where(project => project.UserId == user.Id).ToList();
            foreach (Project p in projects)
            {
                IList<ProjectTask> ProjectTasks = _ProjectPlannerDbContext.ProjectTasks.Where(ProjectTask => ProjectTask.ProjectId == p.Id).ToList();
                foreach (ProjectTask pt in ProjectTasks)
                {
                    _ProjectPlannerDbContext.ProjectTasks.Remove(pt);
                }
                _ProjectPlannerDbContext.Projects.Remove(p);
            }
            _ProjectPlannerDbContext.Users.Remove(user);
            _ProjectPlannerDbContext.SaveChanges();
        }

        public void UpdateProject(Project project)
        {
            Project p = _ProjectPlannerDbContext.Projects.First(p => p.Id == project.Id);
            _ProjectPlannerDbContext.Projects.Remove(p);
            project.UserId = p.UserId;
            project.Id = p.Id;
            _ProjectPlannerDbContext.Projects.Add(project);
            _ProjectPlannerDbContext.SaveChanges();
        }

        public void DeleteProject(int Id)
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

        public void UpdateTask(ProjectTask task)
        {
            ProjectTask p = _ProjectPlannerDbContext.ProjectTasks.First(p => p.Id == task.Id);
            _ProjectPlannerDbContext.ProjectTasks.Remove(p);
            task.ProjectId = p.ProjectId;
            task.Id = p.Id;
            _ProjectPlannerDbContext.ProjectTasks.Add(task);
            _ProjectPlannerDbContext.SaveChanges();
        }

        public void DeleteTask(int Id)
        {
            _ProjectPlannerDbContext.ProjectTasks.Remove(_ProjectPlannerDbContext.ProjectTasks.First(p => p.Id == Id));
            _ProjectPlannerDbContext.SaveChanges();
        }

        public User GetUser(int Id)
        {
            return _ProjectPlannerDbContext.Users.First(u => u.Id == Id);

        }
        public Project GetProject(int Id)
        {
            return _ProjectPlannerDbContext.Projects.First(u => u.Id == Id);

        }
        public ProjectTask GetTask(int Id)
        {
            return _ProjectPlannerDbContext.ProjectTasks.First(u => u.Id == Id);

        }
    }
}
