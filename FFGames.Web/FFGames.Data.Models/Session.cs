using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFGames.Data.Models
{
    public class Session
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<GameSession> GameSessions { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
