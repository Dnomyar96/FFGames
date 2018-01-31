using FFGames.Data;
using FFGames.Data.Models;
using FFGames.Web.Helpers;
using FFGames.Web.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FFGames.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index(string successMessage = "")
        {
            return View(new LoginVM() { SuccessMessage = successMessage });
        }

        public ActionResult Login(LoginVM vm)
        {
            using (var context = new GameContext())
            {
                var user = context.Users.SingleOrDefault(u => u.UserName == vm.UserName);

                if (user == null || !HashHelper.Verify(vm.Password, user.Password))
                    return View("Index", new LoginVM { ErrorMessage = "Invalid combination of username and password" });

                UserHelper.SetCurrentUser(user);

                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            UserHelper.ClearCurrentUser();

            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            return View(new RegisterVM());
        }

        public ActionResult RegisterUser(RegisterVM vm)
        {
            using (var context = new GameContext())
            {
                if (vm.Password != vm.PasswordConfirm)
                    ModelState.AddModelError("Password", "Passwords don't match");

                if (context.Users.Any(u => u.UserName == vm.UserName))
                    ModelState.AddModelError("UserName", "Username is already in use");

                var token = context.RegisterTokens.Where(t => t.Token == vm.RegisterToken && t.AmountAllowed > t.Users.Count).FirstOrDefault();
                if (token == null)
                    ModelState.AddModelError("RegisterToken", "Invalid register token");

                if (!ModelState.IsValid)
                        return View("Register", vm);

                var user = new User
                {
                    UserName = vm.UserName,
                    Password = HashHelper.Hash(vm.Password),
                    RegisterToken = token
                };

                context.Users.Add(user);
                context.SaveChanges();

                return RedirectToAction("Index", new { successMessage = "Register complete. You can now log in." });
            }
        }
    }
}