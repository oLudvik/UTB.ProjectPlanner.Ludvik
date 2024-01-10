using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Application.ViewModels.Admin;

namespace UTB.ProjectPlanner.Application.Abstraction.Admin
{
    public interface IAdminService
    {
        EverythingViewModel Index();
        void UpdateUser();
        void DeleteUser();
        void UpdateProject();
        void DeleteProject();
        void UpdateTask();
        void DeleteTask();
    }
}
