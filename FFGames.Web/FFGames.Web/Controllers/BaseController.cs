using FFGames.Data;
using FFGames.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FFGames.Web.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = UserHelper.GetCurrentUser();

            using (var context = new GameContext())
            {
                if (user == null || context.Users.SingleOrDefault(u => u.Id == user.Id) == null)
                    filterContext.Result = RedirectToAction("Index", "Login");
            }
        }
    }
}