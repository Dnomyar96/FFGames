using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FFGames.Web.Models.Home
{
    public class SessionVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Participants { get; set; }

        public int GamesAmount { get; set; }

        public bool UserIsInSession { get; set; }
    }
}