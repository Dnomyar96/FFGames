﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FFGames.Web.Models.Login
{
    public class LoginVM
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string SuccessMessage { get; set; }

        public string ErrorMessage { get; set; }
    }
}