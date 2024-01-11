using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Application.ViewModels.Admin;
using UTB.ProjectPlanner.Domain.Entities;
using UTB.ProjectPlanner.Infrastructure.Identity;

namespace UTB.ProjectPlanner.Application.Abstraction.Admin
{
    public interface IAdminService
    {
        IList<EverythingViewModel> Index();
        void UpdateUser(User user);
        void DeleteUser(int Id);
        void UpdateProject(Project project);
        void DeleteProject(int Id);
        void UpdateTask(ProjectTask task);
        void DeleteTask(int Id);

        User GetUser(int Id);
        Project GetProject(int Id);
        ProjectTask GetTask(int Id);
    }
}
