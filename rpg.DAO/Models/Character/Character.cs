﻿using System;
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

        public virtual ICollection<Attribute> Attributes { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Talent> Talents { get; set; }

        public Guid CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; }

        public Guid? CampaignPlayerId { get; set; }
        public virtual CampaignPlayer CampaignPlayer { get; set; }
    }
}
