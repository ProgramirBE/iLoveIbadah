using IbadahLover.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Persistence.Contracts
{
    public class IUserSalahActivityRepository : IGenericRepository<UserSalahActivity>
    {
        Task<UserSalahActivity> GetUserSalahActivityWithDetails(int id);
        Task<List<UserSalahActivity>> GetUserSalahActivitiesWithDetails();
        //Task<bool> PerformedAtExists(DateTime performedAt);
    }
}
