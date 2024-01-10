using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Domain.Entities;

namespace UTB.ProjectPlanner.Application.Abstraction.Planner
{
    public interface IProjectTaskService
    {
        ProjectTask Show(int Id, int UserId);
        void Create(ProjectTask projectTask, int UserId);
        void Update(ProjectTask projectTask, int UserId);
        void Delete(int Id, int UserId);
        ProjectTask Get(int Id);
        Project GetProject(int Id);
    }
}
