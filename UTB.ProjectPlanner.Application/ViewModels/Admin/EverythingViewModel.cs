using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Domain.Entities;
using UTB.ProjectPlanner.Infrastructure.Identity;

namespace UTB.ProjectPlanner.Application.ViewModels.Admin
{
    public class ProjectAndTasks
    {
        public Project Project { get; set; }
        public IList<ProjectTask> Tasks { get; set; }
    }
    public class UserAndProjectAndTasks
    {
        public User User { get; set; }
        public IList<ProjectAndTasks> ProjectAndTasks { get; set; }
    }
    public class EverythingViewModel
    {
        public IList<UserAndProjectAndTasks> Everything { get; set; }
    }
}
