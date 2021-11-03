using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.System.Models
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
    }

    public class RollResult
    {
        public List<int> Dices { get; set; } = new List<int>();
        public int Summary { get; set; }
        public int SummaryMultiplied { get; set; }
    }

    public static class RollService
    {
        public static RollResult Roll(Roll roll)
        {
            var random = new Random();
            var result = new RollResult();
            for(var i=0;i<roll.Amount;i++)
            {
                var _roll = random.Next(1, roll.Dice + 1);
                result.Dices.Add(_roll);
                result.Summary += _roll;
            }
            result.Summary += roll.Static;
            result.SummaryMultiplied = result.Summary * roll.Multiplier;
            return result;
        }
    }
}
