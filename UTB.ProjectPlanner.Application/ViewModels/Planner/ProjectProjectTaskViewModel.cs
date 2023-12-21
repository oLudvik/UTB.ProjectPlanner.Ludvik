using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Domain.Entities;

namespace UTB.ProjectPlanner.Application.ViewModels.Planner
{
    public class ProjectProjectTaskViewModel
    {
        public Project Project { get; set; }
        public IList<ProjectTask> ProjectTasks { get; set; }

    }
}
