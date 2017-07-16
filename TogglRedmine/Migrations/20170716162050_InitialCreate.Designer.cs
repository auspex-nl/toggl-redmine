using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TogglRedmine.Configuration;

namespace TogglRedmine.Migrations
{
    [DbContext(typeof(AppStatusSettingsContext))]
    [Migration("20170716162050_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
