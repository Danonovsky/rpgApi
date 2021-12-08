using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Locations.Models.Request
{
    public class AddLocationRequest
    {
        public string Name { get; set; }
        public Guid CampaignId { get; set; }
    }
}
