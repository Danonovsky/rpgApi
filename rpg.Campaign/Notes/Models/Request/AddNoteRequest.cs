using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Notes.Models.Request
{
    public class AddNoteRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CampaignId { get; set; }
    }
}
