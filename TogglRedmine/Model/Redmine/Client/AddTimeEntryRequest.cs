using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TogglRedmine.Model.Redmine.Client
{
    public class AddTimeEntryRequest
    {
        public AddTimeEntryRequest(TimeEntry entry)
        {
            TimeEntry = new AddTimeEntry
            {
                IssueId = entry.Issue?.Id,
                ProjectId = entry.Project?.Id,
                SpentOn = entry.SpentOn,
                Hours = entry.Hours,
                Comments = entry.Comments,
                ActivityId = entry.Activity?.Id
            };
        }

        [JsonProperty("time_entry")]
        public AddTimeEntry TimeEntry { get; }
    }
}
