using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Locations.Models.Response
{
    public class LocationResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CampaignId { get; set; }
        public string Url { get; set; }
    }
}
