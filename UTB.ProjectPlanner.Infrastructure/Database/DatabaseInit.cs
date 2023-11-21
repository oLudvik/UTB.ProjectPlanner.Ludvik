using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Domain.Entities;

namespace UTB.ProjectPlanner.Infrastructure.Database
{
    internal class DatabaseInit
    {

        internal List<WebUser> GetWebUsers()
        {
            List<WebUser> users = new List<WebUser>();
            //users.Add(new WebUser
            //{
            //    Id = 1,
            //    UserName = "admin",
            //    Password = "password",
            //    Email = "admin@email.cz",
            //    Phone = "999 999 999",
            //    Theme = "pastel"
            //});
            //users.Add(new WebUser
            //{
            //    Id = 2,
            //    UserName = "Tom",
            //    Password = "password",
            //    Email = "Tom@email.cz",
            //    Phone = "999 999 999",
            //    Theme = "pastel"
            //});
            //users.Add(new WebUser
            //{
            //    Id = 3,
            //    UserName = "Petr",
            //    Password = "password",
            //    Email = "Petr@email.cz",
            //    Phone = "999 999 999",
            //    Theme = "pastel"
            //});
            return users;
        }

        internal List<Project> GetProjects()//List<WebUser> users)
        {
            List<Project> projects = new List<Project>();
            //projects.Add(new Project
            //{
            //    Id = 1,
            //    Name = "webovka",
            //    Description = "Description",
            //    Owner = users[0],
            //    Deadline = DateTime.Now,
            //    Status = "inProgress"
            //});

            //projects.Add(new Project
            //{
            //    Id = 2,
            //    Name = "mobilni aplikace",
            //    Description = "Description",
            //    Owner = users[1],
            //    Deadline = DateTime.Now,
            //    Status = "inProgress"
            //});

            //projects.Add(new Project
            //{
            //    Id = 3,
            //    Name = "mikrokontroler",
            //    Description = "Description",
            //    Owner = users[2],
            //    Deadline = DateTime.Now,
            //    Status = "inProgress"
            //});
            return projects;
        }

        internal List<ProjectTask> GetProjectTasks()//List<Project> projects)
        {
            List<ProjectTask> projectTasks = new List<ProjectTask>();
            //projectTasks.Add(new ProjectTask
            //{
            //    Id = 1,
            //    Project = projects[0],
            //    Name = "Admin view",
            //    Description = "Description",
            //    Deadline = DateTime.Now,
            //    Status = "inProgress"
            //});
            //projectTasks.Add(new ProjectTask
            //{
            //    Id = 2,
            //    Project = projects[0],
            //    Name = "dbs setup",
            //    Description = "Description",
            //    Deadline = DateTime.Now,
            //    Status = "inProgress"
            //});
            //projectTasks.Add(new ProjectTask
            //{
            //    Id = 3,
            //    Project = projects[1],
            //    Name = "interaktivita",
            //    Description = "Description",
            //    Deadline = DateTime.Now,
            //    Status = "inProgress"
            //});
            //projectTasks.Add(new ProjectTask
            //{
            //    Id = 4,
            //    Project = projects[2],
            //    Name = "registry driver",
            //    Description = "Description",
            //    Deadline = DateTime.Now,
            //    Status = "inProgress"
            //});
            return projectTasks;
        }
    }
}
