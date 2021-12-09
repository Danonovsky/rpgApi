using Microsoft.AspNetCore.Mvc;
using rpg.Campaign.Locations.Models.Request;
using rpg.Campaign.Locations.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Campaign.Locations.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(
            ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("List/{campaignId}")]
        public async Task<IActionResult> GetAll(Guid campaignId)
        {
            var result = await _locationService.GetAll(campaignId);
            if(result != null) return Ok(result);
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _locationService.Get(id);
            if (result != null) return Ok(result);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddLocationRequest request)
        {
            var result = await _locationService.Add(request);
            if (result != null) return Ok(result);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(EditLocationRequest request)
        {
            var result = await _locationService.Update(request);
            if( result != null) return Ok(result);
            return BadRequest(request);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _locationService.Delete(id);
            if (result) return Ok();
            return BadRequest();
        }
    }
}
