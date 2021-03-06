using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using rpg.Campaign.Campaigns.Models.Request;
using rpg.Campaign.Campaigns.Models.Response;
using rpg.Common;
using rpg.Common.Helpers;
using rpg.Common.Models.Response;
using rpg.Common.Services;
using rpg.DAO;
using rpg.DAO.Models.Game;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Campaign.Campaigns.Services
{
    public interface ICampaignService
    {
        public Task<IEnumerable<CampaignResponse>> FindPublicCampaignsAsync();
        public Task<IEnumerable<CampaignResponse>> FindUserCampaignsAsync();
        public Task<IEnumerable<CampaignResponse>> FindGuestCampaignsAsync();
        public Task<CampaignResponse> GetCampaignAsync(Guid id);
        public Task<CampaignResponse> AddCampaignAsync(CampaignRequest request);
        public Task<CampaignResponse> EditCampaignAsync(CampaignRequest request, Guid id);
        public Task<bool> DeleteCampaignAsync(Guid id);
        public Task<SetUrlResponse> SetUrl(Guid id);
        public Task<bool> JoinCampaign(Guid id);
    }

    public class CampaignService : ICampaignService
    {
        private readonly RpgContext _rpgContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IFileService _fileService;

        public CampaignService(
            RpgContext rpgContext,
            IHttpContextAccessor httpContextAccessor,
            IFileService fileService)
        {
            _httpContextAccessor = httpContextAccessor;
            _rpgContext = rpgContext;
            _fileService = fileService;
        }

        public async Task<IEnumerable<CampaignResponse>> FindPublicCampaignsAsync()
        {
            var result = await _rpgContext.Campaigns
                .Where(_ => _.IsPublic)
                .Include(_ => _.User)
                .Include(_ => _.Locations)
                .Include(_ => _.CampaignPlayers)
                .Include(_ => _.Items)
                .Select(_ => new CampaignResponse(_))
                .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<CampaignResponse>> FindUserCampaignsAsync()
        {
            var userId = _httpContextAccessor.GetUserId();
            var result = await _rpgContext.Campaigns
                .Where(_ => _.UserId == userId)
                .Include(_ => _.User)
                .Include(_ => _.Locations)
                .Include(_ => _.CampaignPlayers)
                .Include(_ => _.Items)
                .Select(_ => new CampaignResponse(_))
                .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<CampaignResponse>> FindGuestCampaignsAsync()
        {
            var userId = _httpContextAccessor.GetUserId();
            var result = await _rpgContext.Campaigns
                .Where(_ => _.CampaignPlayers.Any(_ => _.UserId == userId))
                .Include(_ => _.User)
                .Include(_ => _.Locations)
                .Include(_ => _.CampaignPlayers)
                .Include(_ => _.Items)
                .Select(_ => new CampaignResponse(_))
                .ToListAsync();
            return result;
        }

        public async Task<CampaignResponse> GetCampaignAsync(Guid id)
        {
            var result = await _rpgContext.Campaigns
                .Where(_ => _.Id == id)
                .Include(_ => _.User)
                .Include(_ => _.Locations)
                .Include(_ => _.CampaignPlayers)
                .Include(_ => _.Items)
                .Select(_ => new CampaignResponse(_))
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<CampaignResponse> AddCampaignAsync(CampaignRequest request)
        {
            var userId = _httpContextAccessor.GetUserId();
            if (Config.Systems.Equals(request.System)) return null;
            if (_rpgContext.Campaigns.Any(_ => _.Name == request.Name)) return null;
            var model = new DAO.Models.Game.Campaign
            {
                Name = request.Name,
                Description = request.Description,
                IsPublic = request.IsPublic,
                System = Config.Systems.Where(_ => _ == request.System).First(),
                UserId = userId
            };
            _rpgContext.Campaigns.Add(model);
            var result = await _rpgContext.SaveChangesAsync();
            if (result > 0) return new CampaignResponse(model);
            else return null;
        }

        public async Task<bool> DeleteCampaignAsync(Guid id)
        {
            _rpgContext.Campaigns.Remove(
                await _rpgContext.Campaigns.Where(_ => _.Id == id).FirstOrDefaultAsync());
            var result = await _rpgContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<CampaignResponse> EditCampaignAsync(CampaignRequest request, Guid id)
        {
            var fromDb = await _rpgContext.Campaigns.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (fromDb == null) return null;
            fromDb.Name = request.Name;
            fromDb.Description = request.Description;
            fromDb.IsPublic = request.IsPublic;
            _rpgContext.Campaigns.Update(fromDb);
            var result = await _rpgContext.SaveChangesAsync();
            if (result > 0) return new CampaignResponse(fromDb);
            else return null;
        }

        public async Task<SetUrlResponse> SetUrl(Guid id)
        {
            var item = await _rpgContext.Campaigns.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (item == null) return null;

            var url = await _fileService.Upload();
            if (url == null) return null;

            item.Url = url;
            _rpgContext.Update(item);
            int result = await _rpgContext.SaveChangesAsync();

            if (result == 0) return null;
            return new SetUrlResponse
            {
                Url = url
            };
        }

        public async Task<bool> JoinCampaign(Guid id)
        {
            //
            var userId = _httpContextAccessor.GetUserId();
            var campaign = await _rpgContext.Campaigns.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if(campaign == null) return false;
            bool alreadyJoined = (await _rpgContext.Campaigns.Where(_ => _.CampaignPlayers.Any(_ => _.UserId == userId)).ToListAsync()).Count != 0;
            if (alreadyJoined) return false;
            _rpgContext.CampaignPlayers.Add(new CampaignPlayer
            {
                CampaignId = id,
                UserId = userId
            });
            return await _rpgContext.SaveChangesAsync() > 0;
        }
    }
}
