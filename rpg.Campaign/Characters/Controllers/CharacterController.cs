using Microsoft.AspNetCore.Mvc;
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
            ICharacterService characterService
            )
        {
            _characterService = characterService;
        }

        [HttpGet("Get/{characterId}")]
        public async Task<IActionResult> Get(Guid characterId)
        {
            var result = await _characterService.GetAsync(characterId);
            if(result == null) return NotFound();
            else return Ok(result);
        }

        [HttpGet("{campaignId}")]
        public async Task<IActionResult> GetAll(Guid campaignId)
        {
            var result = await _characterService.GetAllAsync(campaignId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCharacterRequest request)
        {
            var result = await _characterService.AddCharacterAsync(request);
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
            var result = _characterService.GetRacesAsync(systemName);
            return Ok(result);
        }

        [HttpDelete("{characterId}")]
        public async Task<IActionResult> Delete(Guid characterId)
        {
            var result = await _characterService.DeleteAsync(characterId);
            if (result) return Ok();
            else return BadRequest();
        }

        [HttpPatch("Img/{id}")]
        public async Task<IActionResult> SetUrl(Guid id)
        {
            if (id == null) return BadRequest();
            var result = await _characterService.SetUrl(id);
            if (result == null) return BadRequest();
            return Ok(result);
        }
    }
}
