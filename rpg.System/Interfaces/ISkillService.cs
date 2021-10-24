using rpg.System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.System.Interfaces
{
    public interface ISkillService
    {
        public List<Skill> GenerateSkills(string raceName);
        public List<Skill> GenerateSkills(string raceName, List<Characteristic> characteristics);
    }
}
