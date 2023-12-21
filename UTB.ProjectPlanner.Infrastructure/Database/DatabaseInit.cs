using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Domain.Entities.Interfaces;
using UTB.ProjectPlanner.Infrastructure.Identity;
using UTB.ProjectPlanner.Domain.Entities;

namespace UTB.ProjectPlanner.Infrastructure.Database
{
    internal class DatabaseInit
    {

        //for Identity tables


        public List<Role> CreateRoles()
        {
            List<Role> roles = new List<Role>();

            Role roleAdmin = new Role()
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106"
            };

            Role roleManager = new Role()
            {
                Id = 2,
                Name = "Manager",
                NormalizedName = "MANAGER",
                ConcurrencyStamp = "be0efcde-9d0a-461d-8eb6-444b043d6660"
            };

            Role rolePlanner = new Role()
            {
                Id = 3,
                Name = "Planner",
                NormalizedName = "PLANNER",
                ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee"
            };


            roles.Add(roleAdmin);
            roles.Add(roleManager);
            roles.Add(rolePlanner);

            return roles;
        }


        public (User, List<IdentityUserRole<int>>) CreateAdminWithRoles()
        {
            User admin = new User()
            {
                Id = 1,
                FirstName = "Adminek",
                LastName = "Adminovy",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.cz",
                NormalizedEmail = "ADMIN@ADMIN.CZ",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEM9O98Suoh2o2JOK1ZOJScgOfQ21odn/k6EYUpGWnrbevCaBFFXrNL7JZxHNczhh/w==",
                SecurityStamp = "SEJEPXC646ZBNCDYSM3H5FRK5RWP2TN6",
                ConcurrencyStamp = "b09a83ae-cfd3-4ee7-97e6-fbcf0b0fe78c",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            List<IdentityUserRole<int>> adminUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 1
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 3
                }
            };

            return (admin, adminUserRoles);
        }


        public (User, List<IdentityUserRole<int>>) CreateManagerWithRoles()
        {
            User manager = new User()
            {
                Id = 2,
                FirstName = "Managerek",
                LastName = "Managerovy",
                UserName = "manager",
                NormalizedUserName = "MANAGER",
                Email = "manager@manager.cz",
                NormalizedEmail = "MANAGER@MANAGER.CZ",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEOzeajp5etRMZn7TWj9lhDMJ2GSNTtljLWVIWivadWXNMz8hj6mZ9iDR+alfEUHEMQ==",
                SecurityStamp = "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6",
                ConcurrencyStamp = "7a8d96fd-5918-441b-b800-cbafa99de97b",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            List<IdentityUserRole<int>> managerUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 3
                }
            };

            return (manager, managerUserRoles);
        }


        public IList<Project> GetProjects()
        {
            IList<Project> projects = new List<Project>();
            projects.Add(new Project
            {
                Id = 1,
                Name = "WebApp",
                Description = "MVC Web application in asp.net 7",
                Deadline = DateTime.Now.AddDays(10),
                Status = "InProgress",
                UserId = 2,

            });
            projects.Add(new Project
            {
                Id = 2,
                Name = "MobilApp",
                Description = "Android mobile application in ionic with React.js",
                Deadline = DateTime.Now.AddDays(10),
                Status = "InProgress",
                UserId = 2,

            });
            return projects;
        }
        public IList<ProjectTask> GetProjectTasks()
        {
            IList<ProjectTask> projectTasks = new List<ProjectTask>();
            projectTasks.Add(new ProjectTask
            {
                Id = 1,
                Name = "Login and register",
                Description = "Allow users to create account and login",
                Deadline = DateTime.Now.AddDays(10),
                Status = "InProgress",
                ProjectId = 1,
            });
            projectTasks.Add(new ProjectTask
            {
                Id = 2,
                Name = "Project creation",
                Description = "Allow users to create Projects",
                Deadline = DateTime.Now.AddDays(10),
                Status = "InProgress",
                ProjectId = 1,
            });
            projectTasks.Add(new ProjectTask
            {
                Id = 3,
                Name = "ProjectTask creation",
                Description = "Allow users to create tasks inside projects",
                Deadline = DateTime.Now.AddDays(10),
                Status = "InProgress",
                ProjectId = 1,
            });
            projectTasks.Add(new ProjectTask
            {
                Id = 4,
                Name = "API integration",
                Description = "integrate API interface into application",
                Deadline = DateTime.Now.AddDays(10),
                Status = "InProgress",
                ProjectId = 2,
            });
            projectTasks.Add(new ProjectTask
            {
                Id = 5,
                Name = "Data caching",
                Description = "Allow application to cache relevant data",
                Deadline = DateTime.Now.AddDays(10),
                Status = "InProgress",
                ProjectId = 2,
            });
            return projectTasks;
        }
    }
}
