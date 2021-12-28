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
        public string System { get; set; }
        public string Url { get; set; }
        public int PlayerCount { get; set; }
        public int LocationCount { get; set; }
        public int ItemCount { get; set; }
        public PublicUserResponse User { get; set; }

        public CampaignResponse(DAO.Models.Game.Campaign campaign)
        {
            Id = campaign.Id;
            Name = campaign.Name;
            Description = campaign.Description;
            IsPublic = campaign.IsPublic;
            System = campaign.System;
            Url = campaign.Url;
            PlayerCount = campaign.Characters.Count;
            LocationCount = campaign.Locations.Count;
            ItemCount = campaign.Items.Count;
            if(campaign.User != null)
                User = new PublicUserResponse(campaign.User);
        }
    }
}
