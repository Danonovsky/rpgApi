using rpg.CallOfCthulhu.Models;
using rpg.System.Interfaces;
using rpg.System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg.CallOfCthulhu.Services
{
    public class CharacteristicService : ICharacteristicService
    {
        public enum Chars
        {
            Strength,
            Constitution,
            Size,
            Dexterity,
            Appearance,
            Intelligence,
            Power,
            Education,
            Luck,
            Sanity,
            HitPoints,
            HitPointsMax,
            MagicPoints,
            MovementRate
        }

        public List<Characteristic> GenerateCharacteristics(string raceName)
        {
            Races races = new Races();
            Race race = races.GetRace(raceName);
            List<Characteristic> result = race.Characteristics;
            result.ForEach(_ =>
            {
                _.Value = RollService.Roll(_.Roll).SummaryMultipied;
            });
            int hp = (result.FindByName(Chars.Constitution.ToString()).Value +
                result.FindByName(Chars.Size.ToString()).Value) / 10;
            int movementRate = 7;

            if(result.FindByName(Chars.Strength.ToString()).Value >= result.FindByName(Chars.Size.ToString()).Value ||
                result.FindByName(Chars.Dexterity.ToString()).Value >= result.FindByName(Chars.Size.ToString()).Value)
            {
                movementRate = 8;
            }
            if (result.FindByName(Chars.Strength.ToString()).Value > result.FindByName(Chars.Size.ToString()).Value || 
                result.FindByName(Chars.Dexterity.ToString()).Value > result.FindByName(Chars.Size.ToString()).Value)
            {
                movementRate = 9;
            }
            result.Add(new Characteristic(result.FindByName(Chars.Power.ToString()).Value)
            {
                Name = Chars.Sanity.ToString()
            });
            result.Add(new Characteristic(hp) { Name = Chars.HitPoints.ToString() });
            result.Add(new Characteristic(hp) { Name = Chars.HitPointsMax.ToString() });
            result.Add(new Characteristic(result.FindByName(Chars.Power.ToString()).Value / 5) { Name = Chars.MagicPoints.ToString() });
            result.Add(new Characteristic(movementRate) { Name = Chars.MovementRate.ToString() });


            return result;
        }
    }
}
