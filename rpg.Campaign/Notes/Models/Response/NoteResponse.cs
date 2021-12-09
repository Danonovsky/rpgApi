using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Campaign.Notes.Models.Response
{
    public class NoteResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public Guid CampaignId { get; set; }
    }
}
