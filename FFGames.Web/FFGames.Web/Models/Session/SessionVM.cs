using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FFGames.Web.Models.Session
{
    public class SessionVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<GameVM> Games { get; set; }

        public IEnumerable<string> Users { get; set; }
    }
}