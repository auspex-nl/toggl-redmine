using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TogglRedmine.Model.Toggl.Client
{
    public class DetailedReportsResponse : TogglResponseBase
    {
        [JsonProperty("data")]
        public DetailedReportCollection Data { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }
    }
}
