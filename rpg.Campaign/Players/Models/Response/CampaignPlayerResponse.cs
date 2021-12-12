using rpg.Auth.Models.Response;
using rpg.Campaign.Characters.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Players.Models.Response
{
    public class CampaignPlayerResponse
    {
        public Guid Id { get; set; }
        public Guid CampaignId { get; set; }
        public CharacterSimpleResponse Character { get; set; }
        public PublicUserResponse User { get; set; }
    }
}
