using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Domain.Entities;

namespace UTB.ProjectPlanner.Infrastructure.Database
{
    public class ProjectPlannerDbContext : DbContext
    {
        public DbSet<Project> Products { get; set; }
        public DbSet<ProjectTask> Carousels { get; set; }
        public DbSet<WebUser> WebUsers { get; set; }


        public ProjectPlannerDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DatabaseInit dbInit = new DatabaseInit();
            modelBuilder.Entity<WebUser>().HasData(dbInit.GetWebUsers());
            modelBuilder.Entity<Project>().HasData(dbInit.GetProjects());
            modelBuilder.Entity<ProjectTask>().HasData(dbInit.GetProjectTasks());
        }
    }
}
