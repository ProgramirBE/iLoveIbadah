using IbadahLover.Application.Contracts.Identity;
using IbadahLover.Domain;
using IbadahLover.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserAccount> GetUserAccount(int id)
        {
            var userAccount = await _userManager.FindByIdAsync(id.ToString());
            return new UserAccount
            {
                Email = userAccount.Email,
                Id = userAccount.Id,
                FullName = userAccount.FullName
            };
        }

        public async Task<List<UserAccount>> GetUserAccounts()
        {
            var userAccounts = await _userManager.GetUsersInRoleAsync("Worshipper");
            return userAccounts.Select(q => new UserAccount
            {
                Id = q.Id,
                Email = q.Email,
                FullName = q.FullName
            }).ToList();
        }
    }
}
