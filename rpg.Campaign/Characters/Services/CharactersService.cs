using rpg.Campaign.Characters.Models.Request;
using rpg.System.Interfaces;
using rpg.System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Characters.Services
{
    public interface ICharacterService
    {
        public Character RollCharacter(CharacterRollRequest request);
        public bool AddCharacter(Character character);
        public List<Characteristic> RollAttributes(CharacterRollRequest request);
        public List<string> GetRaces(string systemName);
    }
    public class CharacterService : ICharacterService
    {
        ISystem system;
        public Character RollCharacter(CharacterRollRequest request)
        {
            system = GetSystem(request.SystemName);
            var result = system.CreateCharacter("Human");
            return result;
        }

        public List<Characteristic> RollAttributes(CharacterRollRequest request)
        {
            system = GetSystem(request.SystemName);
            var result = system.CharacteristicService.GenerateCharacteristics("Human");
            return result;
        }

        public List<string> GetRaces(string systemName)
        {
            system = GetSystem(systemName);
            return system.GetRaces();
        }

        public bool AddCharacter(Character character)
        {
            throw new NotImplementedException();
        }

        private ISystem GetSystem(string systemName)
        {
            return systemName.ToLower() switch
            {
                "cthulhu" => new CallOfCthulhu.Services.CallOfCthulhu(),
                _ => new CallOfCthulhu.Services.CallOfCthulhu(),
            };
        }
    }
}
