using AutoMapper;
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
        private readonly IMapper _mapper;

        public UserService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserAccount> UpdateUserAccountPasswordHash(int id, string currentPasswordHash, string newPasswordHash)
        {
            var userAccount = await _userManager.FindByIdAsync(id.ToString());
            if (userAccount.PasswordHash != currentPasswordHash)
            {
                throw new Exception("Current Password is Incorrect");
            }
            userAccount.PasswordHash = newPasswordHash;
            await _userManager.UpdateAsync(userAccount);
            return _mapper.Map<UserAccount>(userAccount);
        }

        public async Task<UserAccount> UpdateUserAccountEmailConfirmed(int id)
        {
            var userAccount = await _userManager.FindByIdAsync(id.ToString());
            userAccount.EmailConfirmed = true;
            await _userManager.UpdateAsync(userAccount);
            return _mapper.Map<UserAccount>(userAccount);
        }

        //public async Task<UserAccount> GetUserAccount(int id)
        //{
        //    var userAccount = await _userManager.FindByIdAsync(id.ToString());
        //    return _mapper.Map<UserAccount>(userAccount);
        //}

        //public async Task<List<UserAccount>> GetUserAccounts()
        //{
        //    var userAccounts = await _userManager.GetUsersInRoleAsync("Worshipper");
        //    return _mapper.Map<List<UserAccount>>(userAccounts);
        //}
        //public async Task<UserAccount> GetUserAccount(int id)
        //{
        //    var userAccount = await _userManager.FindByIdAsync(id.ToString());
        //    return new UserAccount
        //    {
        //        Email = userAccount.Email,
        //        Id = userAccount.Id,
        //        FullName = userAccount.FullName
        //    };
        //}

        //public async Task<List<UserAccount>> GetUserAccounts()
        //{
        //    var userAccounts = await _userManager.GetUsersInRoleAsync("Worshipper");
        //    return userAccounts.Select(q => new UserAccount
        //    {
        //        Id = q.Id,
        //        Email = q.Email,
        //        FullName = q.FullName
        //    }).ToList();
        //}
    }
}
