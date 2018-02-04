using FFGames.Data;
using FFGames.Data.Models;
using FFGames.Web.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FFGames.Web.Controllers
{
    public class GamesController : Controller
    {
        public ActionResult AddGame(int sessionId)
        {
            using (var context = new GameContext())
            {
                var session = context.Sessions.SingleOrDefault(s => s.Id == sessionId);

                if (session == null)
                    return HttpNotFound();

                var model = new GameVM
                {
                    Id = 0,
                    Name = "",
                    TeamSize = 1,
                    TeamAmount = 0,
                    HasTournament = false,
                    SessionName = session.Name,
                    SessionId = session.Id
                };

                return View(model);
            }
        }

        public ActionResult SaveGame(GameVM vm)
        {
            using(var context = new GameContext())
            {
                var session = context.Sessions.SingleOrDefault(s => s.Id == vm.SessionId);

                if (session == null)
                    return HttpNotFound();

                if (session.GameSessions.Any(g => g.Name == vm.Name))
                    ModelState.AddModelError("Name", "This session already contains a game with this name");

                if (vm.TeamAmount <= 0 && vm.TeamSize <= 0)
                    ModelState.AddModelError("TeamCount", "Make sure amount of teams or team size is set");

                if (!ModelState.IsValid)
                    return View("AddGame", vm);

                var game = new GameSession
                {
                    Name = vm.Name,
                    TeamAmount = vm.TeamAmount,
                    TeamSize = vm.TeamSize
                };

                session.GameSessions.Add(game);
                context.SaveChanges();

                return RedirectToAction("Session", "Session", new { id = vm.SessionId });
            }
        }
    }
}