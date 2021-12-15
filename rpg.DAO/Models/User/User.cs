using System.Collections;
using System.Collections.Generic;
using rpg.DAO.Models.Game;

namespace rpg.DAO.Models.User
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        
        public ICollection<Campaign> Campaigns { get; set; }
        public ICollection<CampaignPlayer> CampaignPlayers { get; set; }
    }
}