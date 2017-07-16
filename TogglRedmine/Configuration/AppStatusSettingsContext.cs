using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TogglRedmine.Configuration
{
    public class AppStatusSettingsContext : DbContext
    {
        public DbSet<AppStatusSettings> AppStatusSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=state.db");
        }
    }
}
