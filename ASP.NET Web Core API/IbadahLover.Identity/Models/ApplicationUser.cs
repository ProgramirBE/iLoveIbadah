using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
