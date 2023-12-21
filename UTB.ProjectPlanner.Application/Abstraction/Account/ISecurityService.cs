using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Infrastructure.Identity;
using UTB.ProjectPlanner.Domain.Entities;

namespace UTB.ProjectPlanner.Application.Abstraction.Account
{
    public interface ISecurityService
    {
        Task<User> FindUserByUsername(string username);
        Task<User> FindUserByEmail(string email);
        Task<IList<string>> GetUserRoles(User user);
        Task<User> GetCurrentUser(ClaimsPrincipal principal);
    }
}
