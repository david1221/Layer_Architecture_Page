﻿// <auto-generated />
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(EFDBContext))]
    [Migration("20191219142646_Init1")]
    partial class Init1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Entityes.Directory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Html");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Directories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Html = "<b>Directory Contexn</b>",
                            Title = "First Directory"
                        },
                        new
                        {
                            Id = 2,
                            Html = "<b>Directory Contexn</b>",
                            Title = "Second Directory"
                        });
                });

            modelBuilder.Entity("DataLayer.Entityes.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DirectoryId");

                    b.Property<string>("Html");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("DirectoryId");

                    b.ToTable("Materials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DirectoryId = 1,
                            Html = "<b>Materials Contexn</b>",
                            Title = "First Materials"
                        },
                        new
                        {
                            Id = 2,
                            DirectoryId = 2,
                            Html = "<b>Materials Contexn</b>",
                            Title = "First Materials"
                        },
                        new
                        {
                            Id = 3,
                            DirectoryId = 1,
                            Html = "<b>Materials Contexn</b>",
                            Title = "First Materials"
                        });
                });

            modelBuilder.Entity("DataLayer.Entityes.Material", b =>
                {
                    b.HasOne("DataLayer.Entityes.Directory", "Directory")
                        .WithMany("Material")
                        .HasForeignKey("DirectoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
