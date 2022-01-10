using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Common.Models
{
    public class RollResult
    {
        public string Roll { get; set; }
        public List<int> Dices { get; set; } = new List<int>();
        public int Summary { get; set; }
        public int SummaryMultiplied { get; set; }
    }
}
