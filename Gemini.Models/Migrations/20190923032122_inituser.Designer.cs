﻿// <auto-generated />
using Gemini.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gemini.Models.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20190923032122_inituser")]
    partial class inituser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Gemini.Models.Sys_User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Mobile");

                    b.Property<string>("Password");

                    b.Property<string>("RealName");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("sys_Users");
                });
#pragma warning restore 612, 618
        }
    }
}
