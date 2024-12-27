using IbadahLover.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Contracts.Persistence
{
    // Repository of All SQL Methods for UserDhikrActivity Entity
    public interface IUserDhikrActivityRepository : IGenericRepository<UserDhikrActivity>
    {
        Task<UserDhikrActivity> GetUserDhikrActivityWithDetails(int id);
        Task<UserDhikrActivity> GetUserDhikrActivityByPerformedOn(int userAccountId, DateTime performedOn, int dhikrTypeId);
        Task<List<UserDhikrActivity>> GetUserDhikrActivitiesWithDetails();
        Task<bool> PerformedOnExists(int userAccountId, DateTime performedOn, int dhikrTypeId);
        Task IncrementTotalPerformed(int userAccountId, DateTime performedOn, int dhikrTypeId);
    }
}
