using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.ProjectPlanner.Application.ViewModels;
using UTB.ProjectPlanner.Infrastructure.Identity.Enums;

namespace UTB.ProjectPlanner.Application.Abstraction.Account
{
    public interface IAccountService
    {
        Task<string[]> Register(RegisterViewModel vm, Roles role);
        Task<bool> Login(LoginViewModel vm);
        Task Logout();
    }
}
