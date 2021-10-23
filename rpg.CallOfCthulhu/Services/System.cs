using rpg.CallOfCthulhu.Services;
using rpg.System.Interfaces;
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
    }
}
