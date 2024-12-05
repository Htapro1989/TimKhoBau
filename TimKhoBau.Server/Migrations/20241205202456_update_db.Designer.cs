﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TimKhoBau.Server.Migrations
{
    [DbContext(typeof(TreasureContext))]
    [Migration("20241205202456_update_db")]
    partial class update_db
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("TimKhoBau.Server.Model.TreasureMap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Matrix")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("P")
                        .HasColumnType("INTEGER");

                    b.Property<int>("m")
                        .HasColumnType("INTEGER");

                    b.Property<int>("n")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TreasureMaps");
                });
#pragma warning restore 612, 618
        }
    }
}