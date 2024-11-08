using DhikrCount.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhikrCount.Application.Persistence.Contracts
{
    // Repository of All SQL Methods for UserActivity Entity
    public interface IUserActivityRepository : IGenericRepository<UserActivity>
    {
        Task<UserActivity> GetUserActivityWithDetails(int id);
        Task<List<UserActivity>> GetUserActivitiesWithDetails();
    }
}
