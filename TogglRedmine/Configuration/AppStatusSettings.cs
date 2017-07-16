using System;
using System.Collections.Generic;
using System.Text;

namespace TogglRedmine.Configuration
{
    public class AppStatusSettings
    {
        public int Id { get; set; }
        public DateTimeOffset LastSynchronized { get; set; }
    }
}
