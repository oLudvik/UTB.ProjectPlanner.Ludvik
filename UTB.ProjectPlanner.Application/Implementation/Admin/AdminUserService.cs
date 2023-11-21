using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Application.Abstraction.Admin;
using UTB.ProjectPlanner.Application.ViewModels.Admin;
using UTB.ProjectPlanner.Domain.Entities;
using UTB.ProjectPlanner.Infrastructure.Database;

namespace UTB.ProjectPlanner.Application.Implementation.Admin
{
    public class AdminWebUserService : IAdminWebUserService
    {
        public List<WebUser> Index()
        {
            return DatabaseFake.WebUsers;
        }
        public WebUser? Show(int Id)
        {
            WebUser? user = DatabaseFake.WebUsers.FirstOrDefault(x => x.Id == Id);
            if(user != null)
            {
                return user;
            }
            return null;
        }

        public void Create(WebUser user)
        {
            //int Id = DatabaseFake.WebUsers.Count;
            // GET LAST ELEMENT IN LIST
            int Id = DatabaseFake.WebUsers[-1].Id;
            user.Id = Id+1;
            DatabaseFake.WebUsers.Add(user);
        }

        public void Update(WebUser user)
        {
            //DatabaseFake.WebUsers[user.Id - 1] = user;
            WebUser userToUpdate = DatabaseFake.WebUsers.FirstOrDefault(x => x.Id ==  user.Id);
            userToUpdate.UserName = user.UserName;
            userToUpdate.Password = user.Password;
            userToUpdate.Phone = user.Phone;
            userToUpdate.Theme = user.Theme;
            userToUpdate.Email = user.Email;

        }
        public void Delete(int Id)
        {
            WebUser? userToDelete = DatabaseFake.WebUsers.FirstOrDefault(y => y.Id == Id);
            if (userToDelete != null)
            {
                DatabaseFake.WebUsers.Remove(userToDelete);
                DatabaseFake.Projects.RemoveAll(project =>
                {
                    if (project.Owner == userToDelete)
                    {
                        DatabaseFake.ProjectTasks.RemoveAll(task => task.Project == project);
                        return true;
                    }
                    return false;
                });
            }
        }

        public List<ProjectAndTaskViewModel> GetProjectAndTasksViewModel()
        {
            List<ProjectAndTaskViewModel> retval = new List<ProjectAndTaskViewModel>();

            DatabaseFake.Projects.ForEach(delegate (Project project)
            {
                ProjectAndTaskViewModel tmp = new ProjectAndTaskViewModel
                {
                    Project = project,
                    ProjectTasks = new List<ProjectTask> { }
                };
                DatabaseFake.ProjectTasks.ForEach(delegate (ProjectTask projectTask)
                {
                    if(projectTask.Project == project)
                    {
                        tmp.ProjectTasks.Add(projectTask);
                    }
                });
                retval.Add(tmp);
            });
            return retval;
        }

        public List<ProjectAndTaskViewModel> ShowUsersProjectsAndTasks(int userId)
        {
            List<ProjectAndTaskViewModel> retval = new List<ProjectAndTaskViewModel>();

            DatabaseFake.Projects.ForEach(delegate (Project project)
            {
                if (project.Owner.Id == userId)
                {
                    ProjectAndTaskViewModel tmp = new ProjectAndTaskViewModel
                    {
                        Project = project,
                        ProjectTasks = new List<ProjectTask> { }
                    };
                    DatabaseFake.ProjectTasks.ForEach(delegate (ProjectTask projectTask)
                    {
                        if (projectTask.Project == project)
                        {
                            tmp.ProjectTasks.Add(projectTask);
                        }
                    });
                    retval.Add(tmp);                    
                }
            });
            return retval;

        }

        public Project? ShowProject(int Id)
        {
            Project? project = DatabaseFake.Projects.FirstOrDefault(x => x.Id == Id);
            if (project != null)
            {
                return project;
            }
            return null;
        }

        public void CreateProject(Project project)
        {

            //GETL ASH ELEMENT IN ARRAY
            int Id = DatabaseFake.Projects.Count;
            project.Id = Id + 1;
            project.Owner = DatabaseFake.WebUsers[0];
            project.Deadline = DateTime.Now;
            DatabaseFake.Projects.Add(project);
        }

        public void UpdateProject(Project project)
        {
            Project projectToUpdate = DatabaseFake.Projects.FirstOrDefault(y => y.Id == project.Id);
            projectToUpdate.Name = project.Name;
            projectToUpdate.Description = project.Description;
            projectToUpdate.Status = project.Status;
        }
        public void DeleteProject(int Id)
        {
            Project projectToDelete = DatabaseFake.Projects.FirstOrDefault(y => y.Id == Id);
            if (projectToDelete != null)
            {
                DatabaseFake.Projects.Remove(projectToDelete);
                DatabaseFake.ProjectTasks.RemoveAll(task => task.Project == projectToDelete);
            }
        }

        public ProjectTask? ShowTask(int Id)
        {
            ProjectTask? task = DatabaseFake.ProjectTasks.FirstOrDefault(x => x.Id == Id);
            if (task != null)
            {
                return task;
            }
            return null;
        }

        public void CreateTask(ProjectTask task)
        {
            //GET LASH ELEMENT IN ARRAY
            int Id = DatabaseFake.ProjectTasks.Count;
            task.Id = Id + 1;
            task.Project = DatabaseFake.Projects[0];
            task.Deadline = DateTime.Now;
            DatabaseFake.ProjectTasks.Add(task);
        }

        public void UpdateTask(ProjectTask task)
        {
            //DatabaseFake.ProjectTasks[task.Id - 1] = task;
            ProjectTask taskToUpdate = DatabaseFake.ProjectTasks.FirstOrDefault(x => x.Id == task.Id);
            taskToUpdate.Name = task.Name;
            taskToUpdate.Status = task.Status;
            taskToUpdate.Description = task.Description;
        }
        public void DeleteTask(int Id)
        {
            ProjectTask? task =DatabaseFake.ProjectTasks.FirstOrDefault(x => x.Id == Id);
            if(task != null)
            {
                DatabaseFake.ProjectTasks.Remove(task);
            }
        }
    }
}
