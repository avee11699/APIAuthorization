﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIAuthorization.Models.UserLogin
{
    public class Login_Details
    {
        [Required]
        [Key]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
