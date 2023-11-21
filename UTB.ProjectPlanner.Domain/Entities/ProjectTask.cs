using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTB.ProjectPlanner.Domain.Entities
{
    public class ProjectTask : Entity<int>
    {
        [Required]
        [ForeignKey(nameof(Project))]
        public Project Project { get; set; }
        [Required]
        [StringLength(70)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string Status { get; set; }

    }
}
