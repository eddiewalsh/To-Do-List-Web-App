﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoListApp.Data;

#nullable disable

namespace ToDoListApp.Migrations
{
    [DbContext(typeof(ToDoListContext))]
    partial class ToDoListContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ToDoListApp.Models.Jobs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isCompleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("JobList");

                    b.HasData(
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2023, 5, 15, 11, 48, 25, 338, DateTimeKind.Local).AddTicks(2914),
                            JobDescription = "For indecfugiat. Temporibus, voluptatibus.",
                            JobTitle = "Charcuterie",
                            isCompleted = false
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
