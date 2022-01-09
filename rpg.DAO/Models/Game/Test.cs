using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.DAO.Models.Game
{
    public class Test : BaseEntity
    {
        public string CharacteristicName { get; set; }
        public string SkillName { get; set; }
        public string DifficultyLevel { get; set; }

        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
