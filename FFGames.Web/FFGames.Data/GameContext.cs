using FFGames.Data.Models;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFGames.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class GameContext : DbContext
    {
        public GameContext() : base("GameContext") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }
    }
}
