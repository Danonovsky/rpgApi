using Microsoft.Extensions.DependencyInjection;
using rpg.Campaign.Campaigns.Services;
using rpg.Campaign.Characters.Services;
using rpg.Campaign.Locations.Services;
using rpg.Campaign.Notes.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign
{
    public static class CampaignExtension
    {
        public static IServiceCollection AddCampaignExtension(this IServiceCollection services)
        {
            services.AddScoped<ICampaignService, CampaignService>();
            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<INoteService, NoteService>();

            return services;
        }
    }
}
