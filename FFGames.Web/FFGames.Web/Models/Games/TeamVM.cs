using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FFGames.Web.Models.Games
{
    public class TeamVM
    {
        public string Name { get; set; }

        public IEnumerable<string> Members { get; set; }
    }
}