using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TogglRedmine.Model.Toggl
{
    public class Currency
    {
        [JsonProperty("currency")]
        public string Name { get; set; }
        [JsonProperty("amount")]
        public double? Amount { get; set; }
    }
}
