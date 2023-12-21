using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Domain.Entities.Interfaces;
using UTB.ProjectPlanner.Infrastructure.Identity;
using UTB.ProjectPlanner.Domain.Entities;

namespace UTB.ProjectPlanner.Infrastructure.Database
{
    public class ProjectPlannerDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }

        public ProjectPlannerDbContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DatabaseInit dbInit = new DatabaseInit();
            modelBuilder.Entity<Project>().HasData(dbInit.GetProjects());
            modelBuilder.Entity<ProjectTask>().HasData(dbInit.GetProjectTasks());


            //Identity - User and Role initialization
            //roles must be added first
            modelBuilder.Entity<Role>().HasData(dbInit.CreateRoles());

            //then, create users ..
            (User admin, List<IdentityUserRole<int>> adminUserRoles) = dbInit.CreateAdminWithRoles();
            (User manager, List<IdentityUserRole<int>> managerUserRoles) = dbInit.CreateManagerWithRoles();

            //.. and add them to the table
            modelBuilder.Entity<User>().HasData(admin, manager);

            //and finally, connect the users with the roles
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(adminUserRoles);
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(managerUserRoles);

            modelBuilder.Entity<Project>().HasOne<User>(e => e.User as User);
        }
    }
}
