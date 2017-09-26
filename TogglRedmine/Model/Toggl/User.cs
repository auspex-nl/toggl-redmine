using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TogglRedmine.Model.Toggl
{
    public class User
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("api_token")]
        public string ApiToken { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("fullname")]
        public string FullName { get; set; }

        
    }
}
