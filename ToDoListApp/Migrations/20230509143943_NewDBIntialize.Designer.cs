﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoListApp.Data;

#nullable disable

namespace ToDoListApp.Migrations
{
    [DbContext(typeof(ToDoListContext))]
    [Migration("20230509143943_NewDBIntialize")]
    partial class NewDBIntialize
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("isCompleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("JobList");

                    b.HasData(
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2023, 5, 9, 15, 39, 43, 145, DateTimeKind.Local).AddTicks(9704),
                            JobDescription = "For indecfugiat. Temporibus, voluptatibus.",
                            JobTitle = "Charcuterie",
                            isCompleted = false
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
