using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace rpg.System.Models
{
    public class Characteristic
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Advancement { get; set; }
        [JsonIgnore]
        public Roll Roll { get; set; }

        public Characteristic() { }
        public Characteristic(int value)
        {
            Value = value;
        }
        public Characteristic(Roll roll)
        {
            Roll = roll;
        }        
    }
}
