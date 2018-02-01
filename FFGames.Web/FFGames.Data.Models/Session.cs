using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFGames.Data.Models
{
    public class Session
    {
        public Session()
        {
            GameSessions = new List<GameSession>();
            Users = new List<User>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<GameSession> GameSessions { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
