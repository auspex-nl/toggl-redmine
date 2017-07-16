using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TogglRedmine.Model.Redmine.Client
{
    public class AddTimeEntry
    {
        [JsonProperty("issue_id")]
        public int? IssueId { get; set; }
        [JsonProperty("project_id")]
        public int? ProjectId { get; set; }
        [JsonProperty("spent_on")]
        public DateTime SpentOn { get; set; }
        [JsonProperty("hours")]
        public double Hours { get; set; }
        [JsonProperty("activity_id")]
        public int? ActivityId { get; set; }
        [JsonProperty("comments")]
        public string Comments { get; set; }

    }
}
