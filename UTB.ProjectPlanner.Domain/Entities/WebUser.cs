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
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Theme { get; set; }
    }
}
