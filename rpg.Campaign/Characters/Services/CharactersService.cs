using rpg.System.Interfaces;
using rpg.System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Characters.Services
{
    public interface ICharacterService
    {
        public Character RollCharacter(string systemName);
    }
    public class CharacterService : ICharacterService
    {
        public Character RollCharacter(string systemName)
        {
            ISystem system;
            switch (systemName.ToLower())
            {
                case "cthulhu":
                    {
                        system = new CallOfCthulhu.Services.CallOfCthulhu();
                        break;
                    }
                default:
                    {
                        system = new CallOfCthulhu.Services.CallOfCthulhu();
                        break;
                    }
            }
            var result = system.CreateCharacter();
            return result;
        }
    }
}
