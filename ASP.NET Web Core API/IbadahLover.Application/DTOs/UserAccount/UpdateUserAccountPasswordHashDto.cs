using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserAccount
{
    public class UpdateUserAccountPasswordHashDto
    {
        //public int Id { get; set; } ////already passed in the url
        public string CurrentPasswordHash { get; set; }
        public string NewPasswordHash { get; set; }
    }
}
