using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FFGames.Web.Models.Session
{
    public class GameVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PlayerCount { get; set; }

        public int TeamSize { get; set; }

        public int TeamAmount { get; set; }

        public int TeamCount { get; set; }

        public bool HasTournament { get; set; }

        public bool TournamentHasStarted { get; set; }
    }
}