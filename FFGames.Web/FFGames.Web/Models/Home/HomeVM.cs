using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FFGames.Web.Models.Home
{
    public class HomeVM
    {
        public IEnumerable<SessionVM> Sessions { get; set; }
    }
}