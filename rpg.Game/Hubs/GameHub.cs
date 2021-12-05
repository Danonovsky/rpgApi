using Microsoft.AspNetCore.SignalR;
using rpg.Common.Models;
using rpg.Common.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Game.Hubs
{
    public class GameHub : Hub
    {
        public async Task BroadcastSingleRoll(Roll roll)
        {
            await Clients.All.SendAsync("broadcastSingleRoll", RollService.Roll(roll));
        }
    }
}