using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TogglRedmine.Model.Redmine.Client
{
    public class TimeEntryActivitiesResponse
    {
        [JsonProperty("time_entry_activities")]
        public ActivityCollection TimeEntryActivities { get; set; }
    }
}
