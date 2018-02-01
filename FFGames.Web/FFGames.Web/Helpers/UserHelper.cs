using FFGames.Data;
using FFGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FFGames.Web.Helpers
{
    public class UserHelper
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public bool IsAdmin { get; set; }

        public const string CURRENTUSER = "currentUser";

        public static void SetCurrentUser(User user)
        {
            HttpContext.Current.Session[CURRENTUSER] = new UserHelper
            {
                Id = user.Id,
                UserName = user.UserName,
                IsAdmin = user.IsAdmin
            };
        }

        public static UserHelper GetCurrentUser()
        {
            return (UserHelper)HttpContext.Current.Session[CURRENTUSER];
        }

        public static User GetCurrentDbUser(GameContext context)
        {
            var user = (UserHelper)HttpContext.Current.Session[CURRENTUSER];

            return context.Users.SingleOrDefault(u => u.Id == user.Id);
        }

        public static void ClearCurrentUser()
        {
            HttpContext.Current.Session[CURRENTUSER] = null;
        }
    }
}