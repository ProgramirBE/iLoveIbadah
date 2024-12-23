using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Domain
{
    public class UserAccountExternalLogin
    {
        public int Id { get; set; }
        [ForeignKey("UserAccount")]
        public int UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }
        public string OAuthProvider { get; set; }
        public string OAuthKey { get; set; }
        public string? OAuthFullName { get; set; } // au cas ou on ne peut extraire le nom de l'utilisateur depuis le provider...
    }
}
