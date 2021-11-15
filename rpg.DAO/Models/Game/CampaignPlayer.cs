using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace rpg.DAO.Models.Game
{
    public class CampaignPlayer : BaseEntity
    {
        public Guid CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; }

        public Guid UserId { get; set; }
        public User.User User { get; set; }

        [ForeignKey("Character")]
        public Guid? CharacterId { get; set; }
        public virtual Character.Character Character { get; set; }
    }
}