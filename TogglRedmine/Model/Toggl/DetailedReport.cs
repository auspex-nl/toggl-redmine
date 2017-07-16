using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TogglRedmine.Model.Toggl
{
    public class DetailedReport
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("pid")]
        public long? ProjectId { get; set; }
        [JsonProperty("tid")]
        public long? TaskId { get; set; }
        [JsonProperty("uid")]
        public long UserId { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("start")]
        public DateTimeOffset Start { get; set; }
        [JsonProperty("end")]
        public DateTimeOffset End { get; set; }
        [JsonProperty("updated")]
        public DateTimeOffset Updated { get; set; }
        [JsonProperty("dur")]
        public long Duration { get; set; }
        [JsonProperty("user")]
        public string User { get; set; }
        [JsonProperty("use_stop")]
        public bool UsedStop { get; set; }
        [JsonProperty("client")]
        public string Client { get; set; }
        [JsonProperty("project")]
        public string Project { get; set; }
        [JsonProperty("project_color")]
        public string ProjectColor { get; set; }
        [JsonProperty("project_hex_color")]
        public string ProjectHexColor { get; set; }
        [JsonProperty("task")]
        public string Task { get; set; }
        [JsonProperty("billable")]
        public double? Billable { get; set; }
        [JsonProperty("is_billable")]
        public bool IsBillable { get; set; }
        [JsonProperty("cur")]
        public string CurrencyName { get; set; }
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
