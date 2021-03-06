using rpg.System.Interfaces;
using rpg.System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rpg.CallOfCthulhu.Config;
using Races = rpg.CallOfCthulhu.Models.Races;
using rpg.Common.Models;
using rpg.Common.Services;

namespace rpg.CallOfCthulhu.Services
{
    public class CharacteristicService : ICharacteristicService
    {
        public List<Characteristic> GenerateCharacteristics(string raceName)
        {
            var race = Races.All.Find(_ => String.Equals(_.Name ,raceName, StringComparison.OrdinalIgnoreCase));
            var result = new List<Characteristic>(race!.Characteristics);
            result.ForEach(_ =>
            {
                _.Value = RollService.Roll(_.Roll).SummaryMultiplied;
            });
            var hp = (result.FindByName(Characteristics.Constitution).Value +
                result.FindByName(Characteristics.Size).Value) / 10;
            var movementRate = 7;

            if(result.FindByName(Characteristics.Strength).Value >= result.FindByName(Characteristics.Size).Value ||
                result.FindByName(Characteristics.Dexterity).Value >= result.FindByName(Characteristics.Size).Value)
            {
                movementRate = 8;
            }
            if (result.FindByName(Characteristics.Strength).Value > result.FindByName(Characteristics.Size).Value || 
                result.FindByName(Characteristics.Dexterity).Value > result.FindByName(Characteristics.Size).Value)
            {
                movementRate = 9;
            }
            result.Add(new Characteristic(result.FindByName(Characteristics.Power).Value)
            {
                Name = Characteristics.Sanity
            });
            result.Add(new Characteristic(hp) { Name = Characteristics.HitPoints });
            result.Add(new Characteristic(hp) { Name = Characteristics.HitPointsMax });
            result.Add(new Characteristic(result.FindByName(Characteristics.Power).Value / 5)
            {
                Name = Characteristics.MagicPoints
            });
            result.Add(new Characteristic(movementRate) { Name = Characteristics.MovementRate });


            return result;
        }

        public RollResult GetCharacteristic(string raceName, string characteristicName)
        {
            var race = Races.All.Find(_ => String.Equals(_.Name ,raceName, StringComparison.OrdinalIgnoreCase));
            if (race == null || !race!.Characteristics
                .Any(_ => String.Equals(_.Name ,characteristicName, StringComparison.OrdinalIgnoreCase)))
            {
                return null;
            }
            var result = race.Characteristics
                .Find(_ => String.Equals(_.Name ,characteristicName, StringComparison.OrdinalIgnoreCase));
            return RollService.Roll(result!.Roll);
        }
    }
}
