using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Application.Abstraction.Admin;
using UTB.ProjectPlanner.Application.ViewModels.Admin;
using UTB.ProjectPlanner.Infrastructure.Database;

namespace UTB.ProjectPlanner.Application.Implementation.Admin
{
    public class AdminService : IAdminService
    {
        ProjectPlannerDbContext _ProjectPlannerDbContext;
        public AdminService(ProjectPlannerDbContext projectPlannerDbContext)
        {
            _ProjectPlannerDbContext = projectPlannerDbContext;
        }
        public EverythingViewModel Index()
        {
            throw new NotImplementedException();
        }
        public void UpdateUser()
        {
            throw new NotImplementedException();
        }

        public void DeleteUser()
        {
            throw new NotImplementedException();
        }

        public void UpdateProject()
        {
            throw new NotImplementedException();
        }

        public void DeleteProject()
        {
            throw new NotImplementedException();
        }

        public void UpdateTask()
        {
            throw new NotImplementedException();
        }

        public void DeleteTask()
        {
            throw new NotImplementedException();
        }
    }
}
