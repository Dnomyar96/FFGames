using FFGames.Data;
using FFGames.Web.Helpers;
using FFGames.Web.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FFGames.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            using (var context = new GameContext())
            {
                var model = new HomeVM();

                model.Sessions = context.Sessions.ToList().Select(s => new SessionVM
                {
                    Id = s.Id,
                    Name = s.Name,
                    Participants = s.Users.Count,
                    GamesAmount = s.GameSessions.Count,
                    UserIsInSession = s.Users.Contains(UserHelper.GetCurrentDbUser(context))
                }).ToList();

                return View(model);
            }
        }
    }
}