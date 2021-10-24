using rpg.System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static rpg.CallOfCthulhu.Services.CharacteristicService;

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
                }
            }
        };

        public Race GetRace(string Name)
        {
            return _races.Where(_ => _.Name == Name).FirstOrDefault();
        }
    }
}
