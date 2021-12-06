using rpg.System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Characters.Models.Request
{
    public class AddCharacterRequest
    {
        public Guid CampaignId { get; set; }
        public Character Character { get; set; }
    }
}
