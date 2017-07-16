using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TogglRedmine.Model.Redmine
{
    public class TimeEntry
    {
        public int Id { get; set; }
        public Project Project { get; set; }

        public Issue Issue { get; set; }

        public User User { get; set; }

        public Activity Activity { get; set; }

        public double Hours { get; set; }
        public string Comments { get; set; }
        [JsonProperty("spent_on")]
        public DateTime SpentOn { get; set; }
        [JsonProperty("created_on")]
        public DateTimeOffset CreatedOn { get; set; }
        [JsonProperty("updated_on")]
        public DateTimeOffset UpdatedOn { get; set; }
    }
}
