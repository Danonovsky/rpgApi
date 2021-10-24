using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.System.Models
{
    public class Character
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Race Race { get; set; }
        public List<Characteristic> Characteristics { get; set; }
    }
}
