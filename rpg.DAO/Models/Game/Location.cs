using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.DAO.Models.Game
{
    public class Location : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Test> Tests { get; set; }

        public Guid CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; }
    }
}
