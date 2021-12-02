using System;
using System.Collections;
using System.Collections.Generic;

namespace rpg.DAO.Models.Game
{
    public class Campaign : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public string System { get; set; }
        public string ImageUrl { get; set; }

        public Guid UserId { get; set; }
        public virtual User.User User { get; set; }

        public virtual ICollection<CampaignPlayer> CampaignPlayers { get; set; }
    }
}