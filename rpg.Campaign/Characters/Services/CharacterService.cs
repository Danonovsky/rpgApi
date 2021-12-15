using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using rpg.Campaign.Characters.Models.Request;
using rpg.Campaign.Characters.Models.Response;
using rpg.Common.Helpers;
using rpg.Common.Models.Response;
using rpg.Common.Services;
using rpg.DAO;
using rpg.System.Interfaces;
using rpg.System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Campaign.Characters.Services
{
    public interface ICharacterService
    {
        public Task<CharacterResponse> GetAsync(Guid id);
        public Task<List<CharacterSimpleResponse>> GetAllAsync(Guid campaignId);
        public Character RollCharacter(CharacterRollRequest request);
        public Task<bool> AddCharacterAsync(AddCharacterRequest request);
        public List<Characteristic> RollAttributes(CharacterRollRequest request);
        public List<string> GetRacesAsync(string systemName);
        public Task<bool> DeleteAsync(Guid id);
        public Task<SetUrlResponse> SetUrl(Guid id);
    }
    public class CharacterService : ICharacterService
    {
        ISystem system;
        private readonly RpgContext _rpgContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IFileService _fileService;

        public CharacterService(
            RpgContext rpgContext,
            IHttpContextAccessor httpContextAccessor,
            IFileService fileService)
        {
            _rpgContext = rpgContext;
            _httpContextAccessor = httpContextAccessor;
            _fileService = fileService;
        }

        public async Task<CharacterResponse> GetAsync(Guid id)
        {
            var result = await _rpgContext.Characters.Where(_ => _.Id == id)
                .Select(character => new CharacterResponse
                {
                    Characteristics = character.Characteristics.Select(_ =>
                    new CharacteristicResponse(_)).ToList(),
                    Skills = character.Skills.Select(_ => new SkillResponse(_)).ToList(),
                    FirstName = character.FirstName,
                    Id = character.Id,
                    LastName = character.LastName,
                    Race = character.Race,
                    Url = character.Url
                }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<CharacterSimpleResponse>> GetAllAsync(Guid campaignId)
        {
            var result = await _rpgContext.Characters
                .Where(_ => _.CampaignId == campaignId)
                .Select(_ => 
                    new CharacterSimpleResponse
                    {
                        Id = _.Id,
                        FirstName = _.FirstName,
                        LastName = _.LastName,
                        Url = _.Url
                    })
                .ToListAsync();
            return result;
        }

        public Character RollCharacter(CharacterRollRequest request)
        {
            system = GetSystem(request.SystemName);
            var result = system.CreateCharacter("Human");
            return result;
        }

        public List<Characteristic> RollAttributes(CharacterRollRequest request)
        {
            system = GetSystem(request.SystemName);
            var result = system.CharacteristicService.GenerateCharacteristics("Human");
            return result;
        }

        public List<string> GetRacesAsync(string systemName)
        {
            system = GetSystem(systemName);
            return system.GetRaces();
        }

        public async Task<bool> AddCharacterAsync(AddCharacterRequest request)
        {
            //throw new NotImplementedException();
            var character = new DAO.Models.Character.Character
            {
                CampaignId = request.CampaignId,
                FirstName = request.Character.FirstName,
                LastName = request.Character.LastName,
                Characteristics = request.Character.Characteristics.Select(_ =>
                    new DAO.Models.Character.Characteristic
                    {
                        Advancement = _.Advancement,
                        Name = _.Name,
                        Value = _.Value
                    }
                ).ToList(),
                Skills = request.Character?.Skills.Select(_ =>
                    new DAO.Models.Character.Skill
                    {
                        Advancement = _.Advancement,
                        Name = _.Name,
                        Value = _.Value
                    }
                ).ToList(),
                Race = request.Character.Race.Name
            };
            _rpgContext.Add(character);
            var result = await _rpgContext.SaveChangesAsync();
            return result > 0;
        }

        private ISystem GetSystem(string systemName)
        {
            return systemName.ToLower() switch
            {
                "cthulhu" => new CallOfCthulhu.Services.CallOfCthulhu(),
                _ => new CallOfCthulhu.Services.CallOfCthulhu(),
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            if(id == null) return false;
            var item = await _rpgContext.Characters
                .Where(_ => _.Id == id)
                .Where(_ => _.Campaign.UserId == _httpContextAccessor.GetUserId())
                .FirstOrDefaultAsync();
            if (item == null) return false;
            var skills = await _rpgContext.Skills
                .Where(_ => _.CharacterId == id)
                .ToListAsync();
            var characteristics = await _rpgContext.Characteristics
                .Where(_ => _.CharacterId == id)
                .ToListAsync();
            _rpgContext.RemoveRange(skills);
            _rpgContext.RemoveRange(characteristics);
            //await _rpgContext.SaveChangesAsync();
            _rpgContext.Remove(item);
            var result = await _rpgContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<SetUrlResponse> SetUrl(Guid id)
        {
            var item = await _rpgContext.Characters.Where(_ => _.Id == id).FirstOrDefaultAsync();
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
