using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.System.Character.Services
{
    public partial interface ICharacterService
    {
        public void CreateCharacter();
        public void UpdateCharacter();
        public void UpdateAttribute();
        public void UpdateSkill();
    }
}
