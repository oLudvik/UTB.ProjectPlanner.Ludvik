using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using UTB.ProjectPlanner.Infrastructure.Identity;
using UTB.ProjectPlanner.Application.Abstraction.Account;

namespace UTB.ProjectPlanner.Application.Implementation
{
    public class SecurityIdentityService : ISecurityService
    {
        UserManager<User> userManager;

        public SecurityIdentityService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public Task<User> FindUserByEmail(string email)
        {
            return userManager.FindByEmailAsync(email);
        }

        public Task<User> FindUserByUsername(string username)
        {
            return userManager.FindByNameAsync(username);
        }

        public Task<User> GetCurrentUser(ClaimsPrincipal principal)
        {
            return userManager.GetUserAsync(principal);
        }

        public Task<IList<string>> GetUserRoles(User user)
        {
            return userManager.GetRolesAsync(user);
        }

        Task<User> ISecurityService.FindUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        Task<User> ISecurityService.FindUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        Task<User> ISecurityService.GetCurrentUser(ClaimsPrincipal principal)
        {
            throw new NotImplementedException();
        }
    }
}
