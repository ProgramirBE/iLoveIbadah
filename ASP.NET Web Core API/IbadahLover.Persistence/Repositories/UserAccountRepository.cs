using IbadahLover.Application.Contracts.Persistence;
using IbadahLover.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Persistence.Repositories
{
    public class UserAccountRepository : GenericRepository<UserAccount>, IUserAccountRepository
    {
        private readonly IbadahLoverDbContext _dbContext;
        public UserAccountRepository(IbadahLoverDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserAccount>> GetUserAccountsWithDetails()
        {
            var userAccounts = await _dbContext.UserAccounts
                .Include(q => q.ProfilePictureType)
                .ToListAsync();
            return userAccounts;
        }

        public async Task<UserAccount> GetUserAccountWithDetails(int id)
        {
            var userAccount = await _dbContext.UserAccounts
                .Include(q => q.ProfilePictureType)
                .FirstOrDefaultAsync(q => q.Id == id);
            return userAccount;
        }

        //public async Task UpdateUserAccountEmailConfirmed(UserAccount userAccount, bool? EmailConfirmed)
        //{
        //    userAccount.EmailConfirmed = EmailConfirmed;
        //    _dbContext.Entry(userAccount).State = EntityState.Modified;
        //    await _dbContext.SaveChangesAsync();
        //}
    }
}
