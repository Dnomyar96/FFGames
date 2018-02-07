using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FFGames.Web.Models.Games
{
    public class GameDetailsVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> Participants { get; set; }

        public IEnumerable<TeamVM> Teams { get; set; }

        public bool CanEditGame { get; set; }
    }
}