using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFGames.Data.Models
{
    public class GameSession
    {
        public GameSession()
        {
            Users = new List<User>();
            Teams = new List<Team>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int TeamSize { get; set; }

        public int TeamAmount { get; set; }

        public int CreatedById { get; set; }

        public virtual Session Session { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
