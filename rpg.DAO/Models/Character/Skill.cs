using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.DAO.Models.Character
{
    public class Skill
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Advancement { get; set; }

        public Guid CharacterId { get; set; }
        public virtual Character Character { get; set; }
    }
}
