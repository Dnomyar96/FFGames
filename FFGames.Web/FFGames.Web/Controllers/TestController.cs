using FFGames.Data;
using FFGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FFGames.Web.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            using (var context = new GameContext())
            {
                var user = context.Users.FirstOrDefault();

                return View(user);
            }
        }

        public ActionResult InsertTest()
        {
            using(var context = new GameContext())
            {
                var user = new User
                {
                    UserName = "Test",
                    Password = "Nog een test"
                };

                context.Users.Add(user);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}