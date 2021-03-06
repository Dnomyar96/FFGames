﻿using FFGames.Data;
using FFGames.Data.Models;
using FFGames.Web.Helpers;
using FFGames.Web.Models.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FFGames.Web.Controllers
{
    public class SessionController : BaseController
    {
        public ActionResult CreateSession()
        {
            return View(new SessionVM());
        }

        [HttpPost]
        public ActionResult SaveSession(SessionVM vm)
        {
            using(var context = new GameContext())
            {
                var session = new Session
                {
                    Name = vm.Name,
                    CreatedBy = UserHelper.GetCurrentUser().Id,
                    DateCreated = DateTime.Now
                };

                context.Sessions.Add(session);
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Session(int id)
        {
            using(var context = new GameContext())
            {
                var session = context.Sessions.SingleOrDefault(s => s.Id == id);

                if (session == null)
                    return HttpNotFound();

                var model = new SessionVM
                {
                    Id = session.Id,
                    Name = session.Name,
                    Games = session.GameSessions.Select(g => new GameVM
                    {
                        Id = g.Id,
                        Name = g.Name,
                        PlayerCount = g.Users.Count,
                        TeamCount = g.Teams.Count,
                        TeamSize = g.TeamSize,
                        UserIsInGame = g.Users.Contains(UserHelper.GetCurrentDbUser(context)),
                        HasTournament = false,
                        TournamentHasStarted = false
                    }).ToList(),
                    Users = session.Users.Select(u => u.UserName)
                };

                return View(model);
            }
        }

        public ActionResult EnterSession(int id)
        {
            using (var context = new GameContext())
            {
                var session = context.Sessions.SingleOrDefault(s => s.Id == id);

                if (session == null)
                    return HttpNotFound();

                session.Users.Add(UserHelper.GetCurrentDbUser(context));
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult LeaveSession(int id)
        {
            using (var context = new GameContext())
            {
                var session = context.Sessions.SingleOrDefault(s => s.Id == id);

                if (session == null)
                    return HttpNotFound();

                session.Users.Remove(UserHelper.GetCurrentDbUser(context));
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
        }
    }
}