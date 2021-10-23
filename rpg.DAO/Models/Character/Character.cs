using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.DAO.Models.Character
{
    public class Character
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Attribute> Attributes { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Talent> Talents { get; set; }
    }
}
