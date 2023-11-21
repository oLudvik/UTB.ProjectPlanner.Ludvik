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
        [Required]
        [StringLength(70)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [ForeignKey(nameof(WebUser))]
        public WebUser Owner { get; set; }

        //public List<WebUser>? Helpers { get; set; }
        public DateTime Deadline { get; set; }
        public string Status {  get; set; }
    }
}
