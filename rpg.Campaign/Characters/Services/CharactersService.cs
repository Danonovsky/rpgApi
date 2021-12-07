using Microsoft.EntityFrameworkCore;
using rpg.Campaign.Characters.Models.Request;
using rpg.Campaign.Characters.Models.Response;
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
        public Task<CharacterResponse> Get(Guid id);
        public Task<List<CharacterSimpleResponse>> GetAll(Guid campaignId);
        public Character RollCharacter(CharacterRollRequest request);
        public Task<bool> AddCharacter(AddCharacterRequest request);
        public List<Characteristic> RollAttributes(CharacterRollRequest request);
        public List<string> GetRaces(string systemName);
    }
    public class CharacterService : ICharacterService
    {
        ISystem system;
        private readonly RpgContext _rpgContext;

        public CharacterService(
            RpgContext rpgContext)
        {
            _rpgContext = rpgContext;
        }

        public async Task<CharacterResponse> Get(Guid id)
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
                }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<CharacterSimpleResponse>> GetAll(Guid campaignId)
        {
            var result = await _rpgContext.Characters
                .Where(_ => _.CampaignId == campaignId)
                .Select(_ => 
                    new CharacterSimpleResponse
                    {
                        Id = _.Id,
                        FirstName = _.FirstName,
                        LastName = _.LastName
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

        public List<string> GetRaces(string systemName)
        {
            system = GetSystem(systemName);
            return system.GetRaces();
        }

        public async Task<bool> AddCharacter(AddCharacterRequest request)
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
                ).ToList()
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
    }
}
