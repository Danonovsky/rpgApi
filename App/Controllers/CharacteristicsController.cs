using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using rpg.CallOfCthulhu;
using rpg.System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rpg.CallOfCthulhu.Services;

namespace App.Controllers
{
    [ApiController]
    [Route("[controller]/{systemName}/{raceName}")]
    public class CharacteristicsController : ControllerBase
    {
        private ISystem System { get; set; }

        private bool SetSystem(string systemName)
        {
            if (String.Equals(systemName, "Cthulhu", StringComparison.OrdinalIgnoreCase))
            {
                System = new CallOfCthulhu();
            }
            return System != null;
        }

        [HttpGet]
        public IActionResult GetCharacteristics(string systemName, string raceName)
        {
            if (!SetSystem(systemName)) { return BadRequest(); }
            var result = System.CharacteristicService.GenerateCharacteristics(raceName);
            return Ok(result);
        }

        [HttpGet("{characteristic}")]
        public IActionResult GetCharacteristic(string systemName, string raceName, string characteristic)
        {
            if (!SetSystem(systemName)) { return BadRequest(); }
            var result = System.CharacteristicService.GetCharacteristic(raceName,characteristic);
            if (result == null) return BadRequest();
            return Ok(result);
        }
    }
}
