using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Auth.Models.Request
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
