using Microsoft.EntityFrameworkCore;
using rpg.Campaign.Locations.Models.Request;
using rpg.Campaign.Locations.Models.Response;
using rpg.Common.Models.Response;
using rpg.Common.Services;
using rpg.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Campaign.Notes.Services
{
    public interface INoteService
    {
        public Task<List<LocationResponse>> GetAll(Guid campaignId);
        public Task<LocationResponse> Get(Guid id);
        public Task<LocationResponse> Add(AddLocationRequest request);
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
        public Task<LocationResponse> Add(AddLocationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<LocationResponse> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LocationResponse>> GetAll(Guid campaignId)
        {
            throw new NotImplementedException();
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
