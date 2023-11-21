using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UTB.ProjectPlanner.Domain.Entities
{
    public abstract class Entity<T>
    {
        [Key]
        [Required]
        public T Id { get; set; }
    }
}
