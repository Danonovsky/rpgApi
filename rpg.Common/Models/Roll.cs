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

        public override string ToString()
        {
            string s = $"{Amount}d{Dice}";
            if (Static > 0) s += $"+{Static}";
            else if (Static < 0) s += $"{Static}";
            if(Multiplier != 1)
            {
                s = $"({s})*{Multiplier}";
            }
            return s;
        }
    }
}
