using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Items.Models.Request
{
    public class AddItemRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CampaignId { get; set; }
    }
}
