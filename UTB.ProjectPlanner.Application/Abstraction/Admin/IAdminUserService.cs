using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Domain.Entities;
using UTB.ProjectPlanner.Application.ViewModels.Admin;

namespace UTB.ProjectPlanner.Application.Abstraction.Admin
{
    public interface IAdminWebUserService
    {
        List<WebUser> Index();
        WebUser? Show(int Id);
        void Create(WebUser user);
        void Update(WebUser user);
        void Delete(int Id);
        List<ProjectAndTaskViewModel> GetProjectAndTasksViewModel();
        List<ProjectAndTaskViewModel> ShowUsersProjectsAndTasks(int userId);
        Project? ShowProject(int Id);
        void CreateProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(int Id);
        ProjectTask? ShowTask(int Id);
        void CreateTask(ProjectTask task);
        void UpdateTask(ProjectTask task);
        void DeleteTask(int Id);
    }
}
