using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTB.ProjectPlanner.Domain.Entities
{
    public class Project : Entity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string Status {  get; set; }
        public virtual WebUser Owner { get; set; }
        public virtual ICollection<ProjectTask> ProjectTasks { get; set; }

    }
}
