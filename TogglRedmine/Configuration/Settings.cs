using System;
using System.Collections.Generic;
using System.Text;

namespace TogglRedmine.Configuration
{
    public class Settings
    {
        public RedmineSettings RedmineSettings { get; set; }
        public TogglSettings TogglSettings { get; set; }

        public Dictionary<string,long> ProjectNameMapping { get; set; }
    }
}
