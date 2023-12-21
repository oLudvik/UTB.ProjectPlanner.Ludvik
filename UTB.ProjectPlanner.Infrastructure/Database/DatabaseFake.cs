using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Infrastructure.Identity;
using UTB.ProjectPlanner.Domain.Entities;

namespace UTB.ProjectPlanner.Infrastructure.Database
{
    public class _db
    {
        public static List<User> Users { get; set; }
        public static List<Project> Projects { get; set; }
        public static List<ProjectTask> ProjectTasks { get; set; }

        static _db()
        {
            DatabaseInit DatabaseInit = new DatabaseInit();
            //WebUsers = DatabaseInit.GetWebUsers();
            //Projects = DatabaseInit.GetProjects(WebUsers);
            //ProjectTasks = DatabaseInit.GetProjectTasks(Projects);
        }
    }
}
