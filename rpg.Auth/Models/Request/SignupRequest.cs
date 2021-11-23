using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Auth.Models.Request
{
    public class SignupRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public string Name { get; set; }

        public bool ComparePasswords()
        {
            return Password.Equals(RepeatPassword);
        }
    }
}
