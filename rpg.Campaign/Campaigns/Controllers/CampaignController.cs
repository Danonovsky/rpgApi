using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using rpg.Auth.Models.Request;
using rpg.Auth.Services;
using rpg.Campaign.Campaigns.Models.Request;
using rpg.Campaign.Campaigns.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Campaign.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private ICampaignService _campaignService;

        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpGet("public")]
        [Authorize]
        public async Task<IActionResult> FindPublicCampaigns()
        {
            return Ok(await _campaignService.FindPublicCampaignsAsync());
        }

        [HttpGet("user")]
        [Authorize]
        public async Task<IActionResult> FindUserCampaigns()
        {
            return Ok(await _campaignService.FindUserCampaignsAsync());
        }

        [HttpGet("guest")]
        [Authorize]
        public async Task<IActionResult> FindGuestCampaigns()
        {
            return Ok(await _campaignService.FindGuestCampaignsAsync());
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetCampaign(Guid id)
        {
            var result = await _campaignService.GetCampaignAsync(id);
            if(result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddCampaign(CampaignRequest request)
        {
            var result = await _campaignService.AddCampaignAsync(request);
            if (result == null) return UnprocessableEntity();
            else return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditCampaign(CampaignRequest request, Guid id)
        {
            if (request == null || id == null) return BadRequest();
            var result = await _campaignService.EditCampaignAsync(request, id);
            if (result == null) return NotFound();
            else return Ok(result);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteCampaign(Guid id)
        {
            if(id == null) return BadRequest();
            var result = await _campaignService.DeleteCampaignAsync(id);
            if (result) return Ok(result);
            else return UnprocessableEntity();
        }
    }
}
