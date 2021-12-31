using Microsoft.EntityFrameworkCore;
using rpg.Campaign.Items.Models.Request;
using rpg.Campaign.Items.Models.Response;
using rpg.Common.Models.Response;
using rpg.Common.Services;
using rpg.DAO;
using rpg.DAO.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Campaign.Items.Services
{
    public interface IItemService
    {
        public Task<List<ItemResponse>> GetAll(Guid campaignId);
        public Task<ItemResponse> Get(Guid id);
        public Task<ItemResponse> Add(AddItemRequest request);
        public Task<bool> Delete(Guid id);
        public Task<SetUrlResponse> SetUrl(Guid id);
    }

    public class ItemService : IItemService
    {
        private readonly RpgContext _rpgContext;
        private readonly IFileService _fileService;

        public ItemService(
            RpgContext rpgContext,
            IFileService fileService)
        {
            _rpgContext = rpgContext;
            _fileService = fileService;
        }
        public async Task<ItemResponse> Add(AddItemRequest request)
        {
            if (request == null) return null;

            var add = await _rpgContext.Items
                .AddAsync(new Item
                {
                    CampaignId = request.CampaignId,
                    CreateDateTime = DateTime.Now,
                    Description = request.Description,
                    Name = request.Name,
                    Url = ""
                });
            var result = await _rpgContext.SaveChangesAsync();
            if (result > 0)
            {
                return new ItemResponse
                {
                    CampaignId = add.Entity.CampaignId,
                    Id = add.Entity.Id,
                    Name = add.Entity.Name,
                    Description = add.Entity.Description,
                    Url = add.Entity.Url
                };
            }
            else return null;
        }

        public async Task<bool> Delete(Guid id)
        {
            if (id == null) return false;
            var item = await _rpgContext.Items
                .Where(_ => _.Id == id)
                .FirstOrDefaultAsync();
            if (item == null) return false;
            _rpgContext.Remove(item);
            var result = await _rpgContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<ItemResponse> Get(Guid id)
        {
            if (id == null) return null;
            var result = await _rpgContext.Items
                .Where(_ => _.Id == id)
                .Select(_ => new ItemResponse
                {
                    CampaignId = _.CampaignId,
                    Description = _.Description,
                    Name = _.Name,
                    Id = _.Id,
                    Url = _.Url
                })
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<ItemResponse>> GetAll(Guid campaignId)
        {
            if (campaignId == null) return null;
            var result = await _rpgContext.Items
                .Where(_ => _.CampaignId == campaignId)
                .Select(_ => new ItemResponse
                {
                    CampaignId = _.CampaignId,
                    Description = _.Description,
                    Name = _.Name,
                    Id = _.Id,
                    Url = _.Url
                })
                .ToListAsync();
            return result;
        }

        public async Task<SetUrlResponse> SetUrl(Guid id)
        {
            var item = await _rpgContext.Items.Where(_ => _.Id == id).FirstOrDefaultAsync();
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
    }
}
