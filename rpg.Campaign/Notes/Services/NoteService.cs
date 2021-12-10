using Microsoft.EntityFrameworkCore;
using rpg.Campaign.Locations.Models.Request;
using rpg.Campaign.Locations.Models.Response;
using rpg.Campaign.Notes.Models.Request;
using rpg.Campaign.Notes.Models.Response;
using rpg.Common.Models.Response;
using rpg.Common.Services;
using rpg.DAO;
using rpg.DAO.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Campaign.Notes.Services
{
    public interface INoteService
    {
        public Task<List<NoteResponse>> GetAll(Guid campaignId);
        public Task<NoteResponse> Get(Guid id);
        public Task<NoteResponse> Add(AddNoteRequest request);
        public Task<bool> Delete(Guid id);
        public Task<SetUrlResponse> SetUrl(Guid id);
    }

    public class NoteService : INoteService
    {
        private readonly RpgContext _rpgContext;
        private readonly IFileService _fileService;

        public NoteService(
            RpgContext rpgContext,
            IFileService fileService)
        {
            _rpgContext = rpgContext;
            _fileService = fileService;
        }
        public async Task<NoteResponse> Add(AddNoteRequest request)
        {
            if (request == null) return null;

            var add = await _rpgContext.Notes
                .AddAsync(new Note
                {
                    CampaignId = request.CampaignId,
                    CreateDateTime = DateTime.Now,
                    Description = request.Description,
                    Title = request.Title,
                    Url = ""
                });
            var result = await _rpgContext.SaveChangesAsync();
            if (result > 0)
            {
                return new NoteResponse
                {
                    CampaignId = add.Entity.CampaignId,
                    Id = add.Entity.Id,
                    Title = add.Entity.Title,
                    Description = add.Entity.Description,
                    Url = add.Entity.Url
                };
            }
            else return null;
        }

        public async Task<bool> Delete(Guid id)
        {
            if (id == null) return false;
            var item = await _rpgContext.Notes
                .Where(_ => _.Id == id)
                .Select(_ => new NoteResponse
                {
                    CampaignId = _.CampaignId,
                    Description = _.Description,
                    Title = _.Title,
                    Id = _.Id,
                    Url = _.Url
                })
                .FirstOrDefaultAsync();
            if (item == null) return false;
            _rpgContext.Remove(item);
            var result = await _rpgContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<NoteResponse> Get(Guid id)
        {
            if (id == null) return null;
            var result = await _rpgContext.Notes
                .Where(_ => _.Id == id)
                .Select(_ => new NoteResponse
                {
                    CampaignId = _.CampaignId,
                    Description = _.Description,
                    Title = _.Title,
                    Id = _.Id,
                    Url = _.Url
                })
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<NoteResponse>> GetAll(Guid campaignId)
        {
            if (campaignId == null) return null;
            var result = await _rpgContext.Notes
                .Where(_ => _.CampaignId == campaignId)
                .Select(_ => new NoteResponse
                {
                    CampaignId = _.CampaignId,
                    Description = _.Description,
                    Title = _.Title,
                    Id = _.Id,
                    Url = _.Url
                })
                .ToListAsync();
            return result;
        }

        public async Task<SetUrlResponse> SetUrl(Guid id)
        {
            var item = await _rpgContext.Notes.Where(_ => _.Id == id).FirstOrDefaultAsync();
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
