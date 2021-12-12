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
        public Task<CampaignPlayerResponse> AssignCharacter(AssignCharacterRequest request);
        public Task<bool> Remove(Guid playerId);

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

        public async Task<CampaignPlayerResponse> AssignCharacter(AssignCharacterRequest request)
        {
            if(request == null) return null;
            var player = await _rpgContext.CampaignPlayers
                .Where(_ => _.Id == request.PlayerId)
                .FirstOrDefaultAsync();
            if (player == null) return null;
            player.CharacterId = request.CharacterId;
            var result = await _rpgContext.SaveChangesAsync();
            if(result > 0)
            {
                return new CampaignPlayerResponse
                {
                    CampaignId = player.CampaignId,
                    Id = player.Id,
                    User = new PublicUserResponse(player.User),
                    Character = new CharacterSimpleResponse
                    {
                        Id = player.Character.Id,
                        LastName = player.Character.LastName,
                        FirstName = player.Character.FirstName
                    }
                };
            }
            return null;
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
