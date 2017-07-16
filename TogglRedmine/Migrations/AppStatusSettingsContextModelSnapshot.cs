using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TogglRedmine.Configuration;

namespace TogglRedmine.Migrations
{
    [DbContext(typeof(AppStatusSettingsContext))]
    partial class AppStatusSettingsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("TogglRedmine.Configuration.AppStatusSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("LastSynchronized");

                    b.HasKey("Id");

                    b.ToTable("AppStatusSettings");
                });
        }
    }
}
