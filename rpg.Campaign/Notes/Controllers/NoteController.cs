using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rpg.Campaign.Notes.Models.Request;
using rpg.Campaign.Notes.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Campaign.Notes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(
            INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _noteService.Get(id);
            if (result == null) return NotFound(id);
            return Ok(result);
        }

        [HttpGet("List/{id}")]
        public async Task<IActionResult> GetAll(Guid campaignId)
        {
            var result = await _noteService.GetAll(campaignId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddNoteRequest request)
        {
            var result = await _noteService.Add(request);
            if (result == null) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _noteService.Delete(id);
            if (result) return Ok();
            return BadRequest();
        }

        [HttpPatch("Img/{id}")]
        public async Task<IActionResult> SetUrl(Guid id)
        {
            if (id == null) return BadRequest();
            var result = await _noteService.SetUrl(id);
            if (result == null) return BadRequest();
            return Ok(result);
        }
    }
}
