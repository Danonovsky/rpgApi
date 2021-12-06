using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Characters.Models.Request
{
    public class CharacterRollRequest
    {
        public string SystemName { get; set; }
        public string Race { get; set; }
        public string Attribute { get; set; }
    }
}
