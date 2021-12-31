using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Items.Models.Response
{
    public class ItemResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public Guid CampaignId { get; set; }
    }
}
