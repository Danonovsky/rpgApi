using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Campaigns.Models.Request
{
    public class SetImageUrlRequest
    {
        public Guid CampaignId { get; set; }
        public IFormFile File { get; set; }
    }
}
