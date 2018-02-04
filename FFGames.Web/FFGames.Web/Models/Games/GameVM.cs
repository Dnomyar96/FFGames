using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FFGames.Web.Models.Games
{
    public class GameVM
    {
        public int Id { get; set; }

        public string SessionName { get; set; }

        public int SessionId { get; set; }

        [Required]
        public string Name { get; set; }

        public int PlayerCount { get; set; }

        public int TeamSize { get; set; }

        public int TeamAmount { get; set; }

        public int TeamCount { get; set; }

        public bool HasTournament { get; set; }

        public bool TournamentHasStarted { get; set; }
    }
}