using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Domain.Entities;

namespace UTB.ProjectPlanner.Infrastructure.Database
{
    public class DatabaseFake
    {
        public static List<WebUser> WebUsers { get; set; }
        public static List<Project> Projects { get; set; }
        public static List<ProjectTask> ProjectTasks { get; set; }

        static DatabaseFake()
        {
            DatabaseInit DatabaseInit = new DatabaseInit();
            WebUsers = DatabaseInit.GetWebUsers();
            Projects = DatabaseInit.GetProjects();
            ProjectTasks = DatabaseInit.GetProjectTasks();
        }
    }
}
