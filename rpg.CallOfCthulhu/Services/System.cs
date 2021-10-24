using rpg.CallOfCthulhu.Services;
using rpg.System.Interfaces;
using rpg.System.Models;
using System;

namespace rpg.CallOfCthulhu
{
    public class CallOfCthulhu : ISystem
    {
        public ICharacterService CharacterService { get; set; }
        public ICharacteristicService CharacteristicService { get; set; }

        public CallOfCthulhu()
        {
            CharacterService = new CharacterService();
            CharacteristicService = new CharacteristicService();
        }

        public Character CreateCharacter()
        {
            Character character = new Character();
            character.Characteristics = CharacteristicService.GenerateCharacteristics("Human");
            return character;
        }
    }
}
