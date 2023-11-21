using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Domain.Entities;

namespace UTB.ProjectPlanner.Application.ViewModels.Admin
{
    public class ProjectAndTaskViewModel
    {
        public required Project Project { get; set; }
        public required List<ProjectTask> ProjectTasks { get; set; }

    }
}
