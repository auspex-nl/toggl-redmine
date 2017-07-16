using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TogglRedmine.Model.Toggl.Client
{
    public abstract class TogglResponseBase
    {
        [JsonProperty("total_grand")]
        public long? TotalGrand { get; set; }

        [JsonProperty("total_billable")]
        public long? TotalBillable { get; set; }

        [JsonProperty("total_currencies")]
        public CurrencyCollection TotalCurrencies { get; set; }
    }
}
