using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TogglRedmine.Model.Toggl.Client
{
    public class UserResponse
    {
        [JsonProperty("data")]
        public User Data { get; set; }
    }
}