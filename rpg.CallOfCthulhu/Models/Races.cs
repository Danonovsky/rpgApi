using rpg.System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rpg.CallOfCthulhu.Config;
using static rpg.CallOfCthulhu.Services.CharacteristicService;
using static rpg.CallOfCthulhu.Services.SkillService;
using rpg.Common.Models;

namespace rpg.CallOfCthulhu.Models
{
    public static class Races
    {
        public static readonly List<Race> All = new List<Race>
        {
            new Race
            {
                Name = Config.Races.Human,
                Characteristics = new List<Characteristic>
                {
                    new Characteristic(new Roll(3,6,0,5)) {Name = Characteristics.Strength},
                    new Characteristic(new Roll(3,6,0,5)) {Name = Characteristics.Constitution},
                    new Characteristic(new Roll(2,6,6,5)) {Name = Characteristics.Size},
                    new Characteristic(new Roll(3,6,0,5)) {Name = Characteristics.Dexterity},
                    new Characteristic(new Roll(3,6,0,5)) {Name = Characteristics.Appearance},
                    new Characteristic(new Roll(2,6,6,5)) {Name = Characteristics.Intelligence},
                    new Characteristic(new Roll(3,6,0,5)) {Name = Characteristics.Power},
                    new Characteristic(new Roll(2,6,6,5)) {Name = Characteristics.Education},
                    new Characteristic(new Roll(3,6,0,5)) {Name = Characteristics.Luck}
                },
                Skills = new List<Skill>
                {
                    new Skill(1) { Name = Skills.Locksmith.ToString() },
                    new Skill(20) { Name = Skills.LibraryUse.ToString() },
                    new Skill(20) { Name = Skills.Listen.ToString() },
                    new Skill(25) { Name = Skills.SpotHidden.ToString() },
                    new Skill(25) { Name = Skills.Brawl.ToString() },
                    new Skill(5) { Name = Skills.FastTalk.ToString() },
                    new Skill(20) { Name = Skills.Handgun.ToString() },
                    new Skill(10) { Name = Skills.Psychology.ToString() }
                }
            }
        };
    }
}
