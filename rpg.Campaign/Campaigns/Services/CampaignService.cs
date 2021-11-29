using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using rpg.Campaign.Campaigns.Models.Request;
using rpg.Campaign.Campaigns.Models.Response;
using rpg.Common.Helpers;
using rpg.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Campaign.Campaigns.Services
{
    public interface ICampaignService
    {
        public Task<IEnumerable<CampaignResponse>> FindPublicCampaignsAsync();
        public Task<IEnumerable<CampaignResponse>> FindUserCampaignsAsync();
        public Task<CampaignResponse> GetCampaignAsync(Guid id);
        public Task<CampaignResponse> AddCampaign(CampaignRequest request);
        public CampaignResponse EditCampaign(CampaignRequest request, Guid id);
        public bool DeleteCampaign(Guid id);
    }

    public class CampaignService : ICampaignService
    {
        private readonly RpgContext _rpgContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CampaignService(
            RpgContext rpgContext,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _rpgContext = rpgContext;
        }

        public async Task<IEnumerable<CampaignResponse>> FindPublicCampaignsAsync()
        {
            var result = await _rpgContext.Campaigns
                .Where(_ => _.IsPublic)
                .Select(_ => new CampaignResponse(_))
                .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<CampaignResponse>> FindUserCampaignsAsync()
        {
            var userId = _httpContextAccessor.GetUserId();
            var result = await _rpgContext.Campaigns
                .Where(_ => _.UserId == userId)
                .Select(_ => new CampaignResponse(_))
                .ToListAsync();
            return result;
        }

        public async Task<CampaignResponse> GetCampaignAsync(Guid id)
        {
            var result = await _rpgContext.Campaigns
                .Where(_ => _.Id == id)
                .Select(_ => new CampaignResponse(_))
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<CampaignResponse> AddCampaign(CampaignRequest request)
        {
            var userId = _httpContextAccessor.GetUserId();
            if (_rpgContext.Campaigns.Any(_ => _.Name == request.Name)) return null;
            var model = new DAO.Models.Game.Campaign
            {
                Name = request.Name,
                Description = request.Description,
                IsPublic = request.IsPublic,
                UserId = userId
            };
            _rpgContext.Campaigns.Add(model);
            var result = await _rpgContext.SaveChangesAsync();
            if (result > 0) return new CampaignResponse(model);
            else return null;

        }

        public bool DeleteCampaign(Guid id)
        {
            throw new NotImplementedException();
        }

        public CampaignResponse EditCampaign(CampaignRequest request, Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CampaignResponse> FindCampaigns(bool isPublic)
        {
            throw new NotImplementedException();
        }
    }
}
