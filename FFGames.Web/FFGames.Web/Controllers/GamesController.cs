using FFGames.Data;
using FFGames.Data.Models;
using FFGames.Web.Helpers;
using FFGames.Web.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FFGames.Web.Controllers
{
    public class GamesController : BaseController
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
                    TeamSize = vm.TeamSize,
                    CreatedById = UserHelper.GetCurrentUser().Id
                };

                session.GameSessions.Add(game);
                context.SaveChanges();

                return RedirectToAction("Session", "Session", new { id = vm.SessionId });
            }
        }

        public ActionResult Game(int id)
        {
            using (var context = new GameContext())
            {
                var game = context.GameSessions.SingleOrDefault(s => s.Id == id);

                if (game == null)
                    return HttpNotFound();

                var model = new GameDetailsVM
                {
                    Id = game.Id,
                    Name = game.Name,
                    Participants = game.Users.Select(u => u.UserName),
                    Teams = game.Teams.Select(t => new TeamVM
                    {
                        Name = t.Name,
                        Members = t.Users.Select(u => u.UserName).ToList()
                    }).ToList(),
                    CanEditGame = UserHelper.GetCurrentUser().IsAdmin || game.CreatedById == UserHelper.GetCurrentUser().Id
                };

                return View(model);
            }
        }

        public ActionResult GenerateTeams(int id)
        {
            using (var context = new GameContext())
            {
                var game = context.GameSessions.SingleOrDefault(s => s.Id == id);

                if (game == null)
                    return HttpNotFound();

                var users = game.Users.Select(u => u.UserName).ToArray();
                int teamSize = 0;

                if (game.TeamSize > 0)
                {
                    teamSize = game.TeamSize;
                }
                else if (game.TeamAmount > 0)
                {
                    teamSize = users.Length / game.TeamAmount;
                }
                else
                {
                    throw new InvalidOperationException("TeamSize and TeamAmount are not set.");
                }

                game.Teams.Clear();

                var count = 0;
                while (users.Length > 0)
                {
                    count++;
                    var team = new Team
                    {
                        Name = $"Team {count}"
                    };

                    for (int i = 0; i < teamSize; i++)
                    {
                        if (users.Length > 0)
                        {
                            var random = new Random().Next(users.Length);
                            var user = users[random];
                            team.Users.Add(context.Users.SingleOrDefault(u => u.UserName == user));
                            users = users.Where(u => u != users[random]).ToArray();
                        }
                    }

                    game.Teams.Add(team);
                }

                context.SaveChanges();

                return RedirectToAction("Game", "Games", new { id = game.Id });
            }
        }

        public ActionResult EnterGame(int id)
        {
            using (var context = new GameContext())
            {
                var game = context.GameSessions.SingleOrDefault(s => s.Id == id);

                if (game == null)
                    return HttpNotFound();

                game.Users.Add(UserHelper.GetCurrentDbUser(context));
                context.SaveChanges();

                return RedirectToAction("Session", "Session", new { id = game.Session.Id });
            }
        }

        public ActionResult LeaveGame(int id)
        {
            using (var context = new GameContext())
            {
                var game = context.GameSessions.SingleOrDefault(s => s.Id == id);

                if (game == null)
                    return HttpNotFound();

                game.Users.Remove(UserHelper.GetCurrentDbUser(context));
                context.SaveChanges();

                return RedirectToAction("Session", "Session", new { id = game.Session.Id });
            }
        }
    }
}