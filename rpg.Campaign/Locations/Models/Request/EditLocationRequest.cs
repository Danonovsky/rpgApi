using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Locations.Models.Request
{
    public class EditLocationRequest : AddLocationRequest
    {
        public Guid Id { get; set; }
    }
}
