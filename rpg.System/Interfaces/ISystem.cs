using rpg.System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.System.Interfaces
{
    public interface ISystem
    {
        public ICharacterService CharacterService { get; set; }
        public ICharacteristicService CharacteristicService { get; set; }
        public ISkillService SkillService { get; set; }
        public Character CreateCharacter();
    }
}
