using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using rpg.Common.Models;
using rpg.Common.Services;
using rpg.Game.Hubs;
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Game.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameHubController: ControllerBase
    {
        private IHubContext<GameHub> _hub;

        public GameHubController(
            IHubContext<GameHub> hub)
        {
            _hub = hub;
        }
    }
}
