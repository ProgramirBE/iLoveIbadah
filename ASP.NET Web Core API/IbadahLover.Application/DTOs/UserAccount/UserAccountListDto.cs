using IbadahLover.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.UserAccount
{
    public class UserAccountListDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UniqueId { get; set; }
        public int? ProfilePictureTypeId { get; set; }
        //[Column(TypeName = "decimal(11, 8)")]
        //public decimal? CurrentLongitude { get; set; }
        //[Column(TypeName = "decimal(10, 8)")]
        //public decimal? CurrentLatitude { get; set; }
        public string? CurrentLocation { get; set; }
        public bool? IsPermanentlyBanned { get; set; }
    }
}
