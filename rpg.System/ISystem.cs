using rpg.System.Character.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.System
{
    public interface ISystem
    {
        public ICharacterService CharacterService { get; set; }
    }
}
