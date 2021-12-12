using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rpg.Campaign.Notes.Models.Request;
using rpg.Campaign.Players.Models.Request;
using rpg.Campaign.Players.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Campaign.Players.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(
            IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("List/{campaignId}")]
        public async Task<IActionResult> GetAll(Guid campaignId)
        {
            var result = await _playerService.GetAll(campaignId);
            return Ok(result);
        }

        [HttpPost("AssignCharacter")]
        public async Task<IActionResult> AssignCharacter(AssignCharacterRequest request)
        {
            var result = await _playerService.AssignCharacter(request);
            if (result == null) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _playerService.Remove(id);
            if (result) return Ok();
            return BadRequest();
        }
    }
}
