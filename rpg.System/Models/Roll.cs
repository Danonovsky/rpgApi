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

        public Roll(int _amount, int _dice, int _static = 0)
        {
            Amount = _amount;
            Dice = _dice;
            Static = _static;
        }
    }

    public class RollResult
    {
        public List<int> Dices { get; set; } = new List<int>();
        public int Summary { get; set; } = 0;
    }

    public class RollService
    {
        public static RollResult Roll(Roll roll)
        {
            Random random = new Random();
            RollResult result = new RollResult();
            for(int i=0;i<roll.Amount;i++)
            {
                int _roll = random.Next(1, roll.Dice + 1);
                result.Dices.Add(_roll);
                result.Summary += _roll;
            }
            result.Summary += roll.Static;
            return result;
        }
    }
}
