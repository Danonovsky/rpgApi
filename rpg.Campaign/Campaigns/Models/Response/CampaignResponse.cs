using rpg.Auth.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Campaigns.Models.Response
{
    public class CampaignResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public PublicUserResponse User { get; set; }
    }
}
