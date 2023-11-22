using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace UTB.ProjectPlanner.Domain.Entities
{
    public class WebUser : Entity<int>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Theme { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
