using rpg.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Common.Services
{
    public static class RollService
    {
        public static RollResult Roll(Roll roll)
        {
            var random = new Random();
            var result = new RollResult();
            for (var i = 0; i < roll.Amount; i++)
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
