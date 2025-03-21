﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mission10_backend.Models;

#nullable disable

namespace Mission10_backend.Migrations
{
    [DbContext(typeof(BowlingLeagueContext))]
    [Migration("20250315043708_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.14");

            modelBuilder.Entity("Mission10_backend.Models.Bowler", b =>
                {
                    b.Property<int>("BowlerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BowlerAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BowlerCity")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BowlerFirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BowlerLastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BowlerMiddleInit")
                        .HasColumnType("TEXT");

                    b.Property<string>("BowlerPhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("BowlerState")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BowlerZip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TeamID")
                        .HasColumnType("INTEGER");

                    b.HasKey("BowlerID");

                    b.HasIndex("TeamID");

                    b.ToTable("Bowlers");
                });

            modelBuilder.Entity("Mission10_backend.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TeamID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Mission10_backend.Models.Bowler", b =>
                {
                    b.HasOne("Mission10_backend.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });
#pragma warning restore 612, 618
        }
    }
}
