using DhikrCount.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhikrCount.Application.Persistence.Contracts
{
    // Repository of All SQL Methods for UserAccount Entity
    public interface IUserAccountRepository : IGenericRepository<UserAccount>
    {
        Task<UserAccount> GetUserAccountWithDetails(int id);
        Task<List<UserAccount>> GetUserAccountsWithDetails();

        //Task ChangeEmailConfirmationStatus(UserAccount userAccount, bool? EmailConfirmationStatus);
    }
}
