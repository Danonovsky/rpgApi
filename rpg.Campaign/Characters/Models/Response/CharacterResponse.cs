using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Characters.Models.Response
{
    public class CharacterResponse : CharacterSimpleResponse
    {
        public string Race { get; set; }
        public List<CharacteristicResponse> Characteristics { get; set; }
        public List<SkillResponse> Skills { get; set; }
    }
}
