﻿using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Players.Models.Request
{
    public class AssignCharacterRequest
    {
        public Guid PlayerId { get; set; }
        public Nullable<Guid> CharacterId { get; set; }
    }
}
