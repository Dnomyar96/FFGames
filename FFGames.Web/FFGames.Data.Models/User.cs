using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFGames.Data.Models
{
    public class User
    {
        public User()
        {
            Sessions = new List<Session>();
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }

        public virtual RegisterToken RegisterToken { get; set; }
    }
}
