using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Items.Models.Request
{
    public class AssignItemToCharacterRequest
    {
        public Guid ItemId { get; set; }
        public Guid CharacterId { get; set; }
    }
}
