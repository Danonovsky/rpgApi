using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Players.Models.Request
{
    public class UnassignCharacterRequest
    {
        public Guid PlayerId { get; set; }
        public Guid CampaignId { get; set; }
    }
}
