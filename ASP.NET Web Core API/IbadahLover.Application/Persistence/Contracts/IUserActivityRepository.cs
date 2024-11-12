using IbadahLover.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Persistence.Contracts
{
    // Repository of All SQL Methods for UserActivity Entity
    public interface IUserActivityRepository : IGenericRepository<UserDhikrActivity>
    {
        Task<UserDhikrActivity> GetUserActivityWithDetails(int id);
        Task<List<UserDhikrActivity>> GetUserActivitiesWithDetails();
        [DataType(DataType.Date)]
        Task<bool> PerformedAtExists(DateTime performedAt);
    }
}
