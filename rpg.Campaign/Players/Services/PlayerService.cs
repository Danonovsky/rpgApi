using Microsoft.EntityFrameworkCore;
using rpg.Auth.Models.Response;
using rpg.Campaign.Characters.Models.Response;
using rpg.Campaign.Players.Models.Request;
using rpg.Campaign.Players.Models.Response;
using rpg.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Campaign.Players.Services
{
    public interface IPlayerService
    {
        public Task<List<CampaignPlayerResponse>> GetAll(Guid campaignId);
        public Task<bool> AssignCharacter(AssignCharacterRequest request);
        public Task<bool> UnassignCharacter(UnassignCharacterRequest request);

        public Task<bool> Remove(Guid playerId);
        public Task<List<CharacterResponse>> GetAvailableCharacters(Guid campaignId);
    }
    public class PlayerService : IPlayerService
    {
        private readonly RpgContext _rpgContext;

        public PlayerService(
            RpgContext rpgContext)
        {
            _rpgContext = rpgContext;
        }

        public async Task<List<CampaignPlayerResponse>> GetAll(Guid campaignId)
        {
            if (campaignId == null) return null;
            var result = await _rpgContext.CampaignPlayers
                .Where(_ => _.CampaignId == campaignId)
                .Select(_ => new CampaignPlayerResponse
                {
                    CampaignId = _.CampaignId,
                    Id = _.Id,
                    User = new PublicUserResponse(_.User),
                    Character = _.CharacterId != null ? new CharacterSimpleResponse
                    {
                        Id = _.Character.Id,
                        FirstName = _.Character.FirstName,
                        LastName = _.Character.LastName
                    } : null
                }).ToListAsync();
            return result;
        }

        public async Task<List<CharacterResponse>> GetAvailableCharacters(Guid campaignId)
        {
            if (campaignId == null) return null;
            var result = await _rpgContext.Characters
                .Where(_ => _.CampaignId == campaignId)
                .Where(_ => _.CampaignPlayerId == null)
                .Select(character => new CharacterResponse
                {
                    Characteristics = character.Characteristics
                        .Select(_ => new CharacteristicResponse(_))
                        .ToList(),
                    Skills = character.Skills
                        .Select(_ => new SkillResponse(_))
                        .ToList(),
                    FirstName = character.FirstName,
                    Id = character.Id,
                    LastName = character.LastName,
                    Race = character.Race,
                }).ToListAsync();
            return result;
        } 

        public async Task<bool> AssignCharacter(AssignCharacterRequest request)
        {
            if(request == null) return false;
            var player = await _rpgContext.CampaignPlayers
                .Where(_ => _.Id == request.PlayerId)
                .Include(_ => _.Character).ThenInclude(_ => _.Skills)
                .Include(_ => _.Character).ThenInclude(_ => _.Characteristics)
                .Include(_ => _.User)
                .FirstOrDefaultAsync();
            if (player == null) return false;
            player.CharacterId = request.CharacterId;

            var character = await _rpgContext.Characters
                .Where(_ => _.Id == request.CharacterId)
                .FirstOrDefaultAsync();
            character.CampaignPlayerId = request.PlayerId;

            var result = await _rpgContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UnassignCharacter(UnassignCharacterRequest request)
        {
            if(request == null) return false;
            var player = await _rpgContext.CampaignPlayers
                .Where(_ => _.Id == request.PlayerId)
                .Where(_ => _.CampaignId == request.CampaignId)
                .FirstOrDefaultAsync();
            if(player == null) return false;
            player.CharacterId = null;

            var character = await _rpgContext.Characters
                .Where(_ => _.CampaignPlayerId == request.PlayerId)
                .Where(_ => _.CampaignId == request.CampaignId)
                .FirstOrDefaultAsync();
            if(character != null)
            {
                character.CampaignPlayerId = null;
            }

            var result = await _rpgContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Remove(Guid playerId)
        {
            if(playerId == null) return false;
            var item = await _rpgContext.CampaignPlayers
                .Where(_ => _.Id == playerId)
                .FirstOrDefaultAsync();
            _rpgContext.Remove(item);
            var result = await _rpgContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
