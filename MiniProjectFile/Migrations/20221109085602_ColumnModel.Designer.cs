﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniProjectFile.Models;

#nullable disable

namespace MiniProjectFile.Migrations
{
    [DbContext(typeof(EntityFrameWork))]
    [Migration("20221109085602_ColumnModel")]
    partial class ColumnModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MiniProjectFile.Models.ColumnModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("HeaderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ImportSourceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImportSourceId");

                    b.ToTable("ColumnModel");
                });

            modelBuilder.Entity("MiniProjectFile.Models.ImportSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Column")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileFormat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ImportSource");
                });

            modelBuilder.Entity("MiniProjectFile.Models.ColumnModel", b =>
                {
                    b.HasOne("MiniProjectFile.Models.ImportSource", null)
                        .WithMany("Columns")
                        .HasForeignKey("ImportSourceId");
                });

            modelBuilder.Entity("MiniProjectFile.Models.ImportSource", b =>
                {
                    b.Navigation("Columns");
                });
#pragma warning restore 612, 618
        }
    }
}
