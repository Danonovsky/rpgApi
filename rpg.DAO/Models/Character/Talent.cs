using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.DAO.Models.Character
{
    public class Talent : BaseEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public Guid CharacterId { get; set; }
        public virtual Character Character { get; set; }
    }
}
