using rpg.System.Interfaces;
using rpg.System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rpg.CallOfCthulhu.Config;
using Races = rpg.CallOfCthulhu.Models.Races;

namespace rpg.CallOfCthulhu.Services
{
    public class SkillService : ISkillService
    {
        public List<Skill> GenerateSkills(string raceName)
        {
            var race = Races.All.Where(_ => _.Name == raceName).FirstOrDefault();
            List<Skill> result = race.Skills.ToList();
            return result;
        }

        public List<Skill> GenerateSkills(string raceName, List<Characteristic> characteristics)
        {
            var result = GenerateSkills(raceName);
            result.Add(new Skill(characteristics.FindByName(Characteristics.Dexterity).Value / 2) 
            { Name = Skills.Dodge });
            result.Add(new Skill(characteristics.FindByName(Characteristics.Education).Value)
            { Name = Skills.LanguageOwn });
            return result;
        }
    }
}
