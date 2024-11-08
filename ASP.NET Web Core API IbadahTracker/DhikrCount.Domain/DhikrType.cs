using DhikrCount.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhikrCount.Domain
{
    //Database Table DhikrType
    public class DhikrType : BaseDomainEntity
    {
        public string FullName { get; set; }
    }
}
