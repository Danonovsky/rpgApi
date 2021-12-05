using Microsoft.AspNetCore.Mvc;
using rpg.Campaign.Characters.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Characters.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CharacterController: ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(
            ICharacterService characterService)
        {
            _characterService = characterService;
        }
        [HttpPost("Add")]
        public IActionResult Add()
        {
            return Ok();
        }

        [HttpGet("RollAll/{systemName}")]
        public IActionResult Character(string systemName)
        {
            var result = _characterService.RollCharacter(systemName);
            return Ok(result);
        }
    }
}
