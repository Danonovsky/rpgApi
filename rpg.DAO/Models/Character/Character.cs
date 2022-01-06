using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using rpg.DAO.Models.Game;

namespace rpg.DAO.Models.Character
{
    public class Character : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Race { get; set; }
        public string Url { get; set; }

        public virtual ICollection<Characteristic> Characteristics { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Item> Items { get; set; }

        public Guid CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; }

        public Guid? CampaignPlayerId { get; set; }
        public virtual CampaignPlayer CampaignPlayer { get; set; }
    }
}
