using IbadahLover.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Domain
{
    public class ProfilePictureType : BaseDomainEntity
    {
        public byte[] Base64Code { get; set; }
    }
}
