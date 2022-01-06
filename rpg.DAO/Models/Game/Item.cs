using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.DAO.Models.Game
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public Guid CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; }
        public Guid? CharacterId { get; set; }
        public virtual Character.Character Character { get; set; }
        public Guid? LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
