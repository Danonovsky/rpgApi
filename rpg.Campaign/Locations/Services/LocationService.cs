﻿using Microsoft.EntityFrameworkCore;
using rpg.Campaign.Locations.Models.Request;
using rpg.Campaign.Locations.Models.Response;
using rpg.DAO;
using rpg.DAO.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Campaign.Locations.Services
{
    public interface ILocationService
    {
        public Task<List<LocationResponse>> GetAll(Guid campaignId);
        public Task<LocationResponse> Get(Guid id);
        public Task<LocationResponse> Add(AddLocationRequest request);
        public Task<LocationResponse> Update(EditLocationRequest request);
        public Task<bool> Delete(Guid id);
    }

    public class LocationService : ILocationService
    {
        private readonly RpgContext _rpgContext;

        public LocationService(
            RpgContext rpgContext)
        {
            _rpgContext = rpgContext;
        }

        public async Task<List<LocationResponse>> GetAll(Guid campaignId)
        {
            if(campaignId == null) return null;
            var result = await _rpgContext.Locations
                .Where(_ => _.CampaignId == campaignId)
                .Select(location => new LocationResponse
                {
                    CampaignId = location.CampaignId,
                    Id = location.Id,
                    Name = location.Name
                })
                .ToListAsync();
            return result;
        }
        public async Task<LocationResponse> Get(Guid id)
        {
            if(id == null) return null;
            var result = await _rpgContext.Locations
                .Where(_ => _.Id == id)
                .Select(_ => new LocationResponse
                {
                    Id = _.Id,
                    Name = _.Name,
                    CampaignId = _.CampaignId
                })
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<LocationResponse> Add(AddLocationRequest request)
        {
            if(request == null) return null;
            var add = await _rpgContext.AddAsync(new Location
            {
                CampaignId = request.CampaignId,
                Name = request.Name
            });
            var result = await _rpgContext.SaveChangesAsync();
            if (result > 0) 
            {
                return new LocationResponse
                {
                    Name = add.Entity.Name,
                    CampaignId=add.Entity.CampaignId,
                    Id = add.Entity.Id
                };
            }
            return null;
        }
        public async Task<LocationResponse> Update(EditLocationRequest request)
        {
            if(request == null) return null;
            var fromDb = await _rpgContext.Locations
                .Where(_ => _.Id == request.Id)
                .FirstOrDefaultAsync();
            if(fromDb == null) return null;
            fromDb.Name = request.Name;
            var result = await _rpgContext.SaveChangesAsync();
            if (result > 0)
            {
                return new LocationResponse
                {
                    Id = fromDb.Id,
                    Name = fromDb.Name,
                    CampaignId = fromDb.CampaignId
                };
            }
            return null;
        }

        public async Task<bool> Delete(Guid id)
        {
            if(id == null) return false;
            var fromDb = await _rpgContext.Locations
                .Where(_ => _.Id == id)
                .FirstOrDefaultAsync();
            _rpgContext.Remove(fromDb);
            var result = await _rpgContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
