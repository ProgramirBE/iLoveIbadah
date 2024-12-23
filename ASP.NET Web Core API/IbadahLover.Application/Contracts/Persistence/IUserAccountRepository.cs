using IbadahLover.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Contracts.Persistence
{
    // Repository of All SQL Methods for UserAccount Entity
    public interface IUserAccountRepository : IGenericRepository<UserAccount>
    {
        Task<UserAccount> GetUserAccountWithDetails(int id);
        Task<List<UserAccount>> GetUserAccountsWithDetails();
        //Task UpdateUserAccountEmailConfirmed(UserAccount userAccount, bool? EmailConfirmed);
    }
}
