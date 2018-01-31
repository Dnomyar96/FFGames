using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFGames.Data.Models
{
    public class RegisterToken
    {
        public RegisterToken()
        {
            Users = new List<User>();
        }

        public int Id { get; set; }

        public string Token { get; set; }

        public int AmountAllowed { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
