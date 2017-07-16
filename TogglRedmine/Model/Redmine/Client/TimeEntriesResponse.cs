using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TogglRedmine.Model.Redmine.Client
{
    public class TimeEntriesResponse
    {
        [JsonProperty("time_entries")]
        public TimeEntryCollection TimeEntries { get; set; }
    }
}
