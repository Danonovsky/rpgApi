using rpg.System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.System.Interfaces
{
    public interface ICharacterService
    {
        public void UpdateCharacter();
        public void UpdateAttribute();
        public void UpdateSkill();
    }
}
