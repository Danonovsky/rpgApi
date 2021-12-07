using rpg.DAO.Models.Character;
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Characters.Models.Response
{
    public class CharacteristicResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int Advancement { get; set; }

        public CharacteristicResponse() { }
        public CharacteristicResponse(Characteristic characteristic)
        {
            Id = characteristic.Id;
            Name = characteristic.Name;
            Value = characteristic.Value;
            Advancement = characteristic.Advancement;
        }
    }
}
