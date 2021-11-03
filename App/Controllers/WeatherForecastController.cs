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
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = 
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Attributes")]
        public IActionResult TestAttributes()
        {
            ISystem system = new CallOfCthulhu();
            var result = system.CharacteristicService.GenerateCharacteristics("Human");
            return Ok(result);
        }

        [HttpGet("Character/{systemName}")]
        public IActionResult Character(string systemName)
        {
            ISystem system;
            switch(systemName)
            {
                case "Cthulhu":
                    {
                        system = new CallOfCthulhu();
                        break;
                    }
                default:
                    {
                        system = new CallOfCthulhu();
                        break;
                    }
            }
            var result = system.CreateCharacter();
            return Ok(result);
        }
    }
}
