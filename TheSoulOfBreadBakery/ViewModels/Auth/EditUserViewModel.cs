﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheSoulOfBreadBakery.ViewModels.Auth
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Please enter the user name")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter the user email")]
        public string Email { get; set; }

        public List<string> UserClaims { get; set; }
    }
}
