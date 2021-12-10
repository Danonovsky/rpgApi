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
    [Authorize]
    public class CampaignController : ControllerBase
    {
        private ICampaignService _campaignService;

        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpGet("public")]
        public async Task<IActionResult> FindPublicCampaigns()
        {
            return Ok(await _campaignService.FindPublicCampaignsAsync());
        }

        [HttpGet("user")]
        public async Task<IActionResult> FindUserCampaigns()
        {
            return Ok(await _campaignService.FindUserCampaignsAsync());
        }

        [HttpGet("guest")]
        public async Task<IActionResult> FindGuestCampaigns()
        {
            return Ok(await _campaignService.FindGuestCampaignsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCampaign(Guid id)
        {
            var result = await _campaignService.GetCampaignAsync(id);
            if(result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCampaign(CampaignRequest request)
        {
            var result = await _campaignService.AddCampaignAsync(request);
            if (result == null) return UnprocessableEntity();
            else return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCampaign(CampaignRequest request, Guid id)
        {
            if (request == null || id == null) return BadRequest();
            var result = await _campaignService.EditCampaignAsync(request, id);
            if (result == null) return NotFound();
            else return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCampaign(Guid id)
        {
            if(id == null) return BadRequest();
            var result = await _campaignService.DeleteCampaignAsync(id);
            if (result) return Ok(result);
            else return UnprocessableEntity();
        }

        [HttpPatch("Img/{id}")]
        public async Task<IActionResult> SetUrl(Guid id)
        {
            if(id == null) return BadRequest();
            var result = await _campaignService.SetUrl(id);
            if (result == null) return BadRequest();
            return Ok(result);
        }

        [HttpGet("Join/{id}")]
        public async Task<IActionResult> JoinCampaign(Guid id)
        {
            var result = await _campaignService.JoinCampaign(id);
            if (result) return Ok(result);
            else return BadRequest();
        }
    }
}
