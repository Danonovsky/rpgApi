using Microsoft.AspNetCore.Http;
using rpg.Campaign.Campaigns.Models.Request;
using rpg.Campaign.Campaigns.Models.Response;
using rpg.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Campaigns.Services
{
    public interface ICampaignService
    {
        public IEnumerable<CampaignResponse> FindCampaigns(bool isPublic);
        public CampaignResponse GetCampaign(Guid id);
        public CampaignResponse AddCampaign(CampaignRequest request);
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

        public CampaignResponse AddCampaign(CampaignRequest request)
        {
            //_httpContextAccessor.HttpContext.User;
            throw new NotImplementedException();
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

        public CampaignResponse GetCampaign(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
