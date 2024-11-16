using IbadahLover.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Persistence.Contracts
{
    // Repository of All SQL Methods for UserDhikrActivity Entity
    public interface IUserDhikrActivityRepository : IGenericRepository<UserDhikrActivity>
    {
        Task<UserDhikrActivity> GetUserDhikrActivityWithDetails(int id);
        Task<List<UserDhikrActivity>> GetUserDhikrActivitiesWithDetails();
        [DataType(DataType.Date)]
        Task<bool> PerformedAtExists(DateTime performedAt);
    }
}
