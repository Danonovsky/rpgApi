using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Characters.Models.Response
{
    public class CharacterSimpleResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
