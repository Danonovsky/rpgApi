using rpg.DAO.Models.Character;
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Characters.Models.Response
{
    public class SkillResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int Advancement { get; set; }

        public SkillResponse() { }
        public SkillResponse(Skill skill)
        {
            Id = skill.Id;
            Name = skill.Name;
            Value = skill.Value;
            Advancement = skill.Advancement;
        }
    }
}
