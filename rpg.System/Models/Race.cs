using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace rpg.System.Models
{
    public class Race
    {
        public string Name { get; set; }
        [JsonIgnore]
        public List<Characteristic> Characteristics { get; set; }
        [JsonIgnore]
        public List<Skill> Skills { get; set; }
    }
}
