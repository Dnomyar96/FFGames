using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFGames.Data.Models
{
    public class Team
    {
        public Team()
        {
            Users = new List<User>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual GameSession GameSession { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
