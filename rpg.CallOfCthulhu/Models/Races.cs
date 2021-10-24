using rpg.System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static rpg.CallOfCthulhu.Services.CharacteristicService;
using static rpg.CallOfCthulhu.Services.SkillService;

namespace rpg.CallOfCthulhu.Models
{
    public class Races
    {
        private List<Race> _races = new List<Race>
        {
            new Race
            {
                Name = "Human",
                Characteristics = new List<Characteristic>
                {
                    new Characteristic(new Roll(3,6,0,5)) {Name = Chars.Strength.ToString()},
                    new Characteristic(new Roll(3,6,0,5)) {Name = Chars.Constitution.ToString()},
                    new Characteristic(new Roll(2,6,6,5)) {Name = Chars.Size.ToString()},
                    new Characteristic(new Roll(3,6,0,5)) {Name = Chars.Dexterity.ToString()},
                    new Characteristic(new Roll(3,6,0,5)) {Name = Chars.Appearance.ToString()},
                    new Characteristic(new Roll(2,6,6,5)) {Name = Chars.Intelligence.ToString()},
                    new Characteristic(new Roll(3,6,0,5)) {Name = Chars.Power.ToString()},
                    new Characteristic(new Roll(2,6,6,5)) {Name = Chars.Education.ToString()},
                    new Characteristic(new Roll(3,6,0,5)) {Name = Chars.Luck.ToString()}
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

        public Race GetRace(string Name)
        {
            return _races.Where(_ => _.Name == Name).FirstOrDefault();
        }
    }
}
