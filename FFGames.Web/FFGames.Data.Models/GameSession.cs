using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFGames.Data.Models
{
    public class GameSession
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Session Session { get; set; }
    }
}
