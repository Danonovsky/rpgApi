﻿using Microsoft.AspNetCore.Mvc;
using rpg.Campaign.Characters.Models.Request;
using rpg.Campaign.Characters.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Campaign.Characters.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(
            ICharacterService characterService)
        {
            _characterService = characterService;
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCharacterRequest request)
        {
            var result = await _characterService.AddCharacter(request);
            if (result)
            {
                return Ok();
            } else
            {
                return BadRequest();
            }
        }

        [HttpPost("RollAll")]
        public IActionResult Character(CharacterRollRequest request)
        {
            var result = _characterService.RollCharacter(request);
            return Ok(result);
        }

        [HttpPost("RollAttributes")]
        public IActionResult RollAttributes(CharacterRollRequest request)
        {
            var result = _characterService.RollAttributes(request);
            return Ok(result);
        }

        [HttpGet("Races/{systemName}")]
        public IActionResult GetRaces(string systemName)
        {
            var result = _characterService.GetRaces(systemName);
            return Ok(result);
        }
    }
}