using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Common.Models
{
    public class Roll
    {
        public int Amount { get; set; }
        public int Dice { get; set; }
        public int Static { get; set; }
        public int Multiplier { get; set; }

        public Roll(int amount, int dice, int @static = 0, int multiplier = 1)
        {
            Amount = amount;
            Dice = dice;
            Static = @static;
            Multiplier = multiplier;
        }

        public Roll() { }
    }
}
