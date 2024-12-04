using IbadahLover.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Persistence.Contracts
{
    public interface IUserSalahOverviewRepository : IGenericRepository<UserSalahOverview>
    {
        Task<UserSalahOverview> GetUserSalahOverviewWithDetails(int id);
        Task<List<UserSalahOverview>> GetUserSalahOverviewsWithDetails();
    }
}
