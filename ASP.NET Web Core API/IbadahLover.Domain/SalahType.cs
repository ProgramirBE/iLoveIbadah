using IbadahLover.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Domain
{
    //Database Table DhikrType
    public class SalahType : BaseDomainEntity
    {
        public string FullName { get; set; }
    }
}
