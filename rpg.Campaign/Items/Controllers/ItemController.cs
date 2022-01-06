using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rpg.Campaign.Items.Models.Request;
using rpg.Campaign.Items.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Campaign.Items.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(
            IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _itemService.Get(id);
            if (result == null) return NotFound(id);
            return Ok(result);
        }

        [HttpGet("List/{campaignId}")]
        public async Task<IActionResult> GetAll(Guid campaignId)
        {
            var result = await _itemService.GetAll(campaignId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddItemRequest request)
        {
            var result = await _itemService.Add(request);
            if (result == null) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _itemService.Delete(id);
            if (result) return Ok();
            return BadRequest();
        }

        [HttpPatch("Img/{id}")]
        public async Task<IActionResult> SetUrl(Guid id)
        {
            if (id == null) return BadRequest();
            var result = await _itemService.SetUrl(id);
            if (result == null) return BadRequest();
            return Ok(result);
        }

        [HttpGet("Available/{campaignId}")]
        public async Task<IActionResult> GetAllAvailable(Guid campaignId)
        {
            var result = await _itemService.GetAvailable(campaignId);
            if(result == null) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _itemService.Remove(id);
            if(!result) return BadRequest();
            return Ok();
        }

        [HttpPost("AssignToCharacter")]
        public async Task<IActionResult> AssignToCharacter(AssignItemToCharacterRequest request)
        {
            var result = await _itemService.AssignToCharacter(request);
            if (!result) return BadRequest();
            return Ok();
        }
    }
}
