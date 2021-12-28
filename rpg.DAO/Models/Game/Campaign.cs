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
        public string? Url { get; set; }

        public Guid UserId { get; set; }
        public virtual User.User User { get; set; }

        public virtual ICollection<Character.Character> Characters { get; set; }
        public virtual ICollection<CampaignPlayer> CampaignPlayers { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}