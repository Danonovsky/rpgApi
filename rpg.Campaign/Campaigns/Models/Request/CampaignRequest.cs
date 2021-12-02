using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Campaigns.Models.Request
{
    public class CampaignRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public string System { get; set; }
    }
}
