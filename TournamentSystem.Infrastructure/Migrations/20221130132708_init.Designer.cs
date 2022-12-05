﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TournamentSystem.Infrastructure.Contexts;

#nullable disable

namespace TournamentSystem.Infrastructure.Migrations
{
    [DbContext(typeof(TournamentSystemContext))]
    [Migration("20221130132708_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TournamentSystem.Application.Features.Matches.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("LostTeamId")
                        .HasColumnType("int");

                    b.Property<int>("MatchRank")
                        .HasColumnType("int");

                    b.Property<int?>("TournamentId")
                        .HasColumnType("int");

                    b.Property<int?>("WinnerTeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.HasIndex("WinnerTeamId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("TournamentSystem.Application.Features.Players.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("HasParticipated")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("TournamentSystem.Application.Features.Teams.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("TournamentSystem.Application.Features.Tournaments.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WinnerTeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WinnerTeamId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("TournamentSystem.Application.Features.Tournaments.TournamentTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("TournamentId");

                    b.ToTable("TournamentTeams");
                });

            modelBuilder.Entity("TournamentSystem.Application.Features.Matches.Match", b =>
                {
                    b.HasOne("TournamentSystem.Application.Features.Tournaments.Tournament", "Tournament")
                        .WithMany("Matches")
                        .HasForeignKey("TournamentId");

                    b.HasOne("TournamentSystem.Application.Features.Teams.Team", "WinnerTeam")
                        .WithMany("Matches")
                        .HasForeignKey("WinnerTeamId");

                    b.Navigation("Tournament");

                    b.Navigation("WinnerTeam");
                });

            modelBuilder.Entity("TournamentSystem.Application.Features.Players.Player", b =>
                {
                    b.HasOne("TournamentSystem.Application.Features.Teams.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("TournamentSystem.Application.Features.Tournaments.Tournament", b =>
                {
                    b.HasOne("TournamentSystem.Application.Features.Teams.Team", "WinnerTeam")
                        .WithMany("WonTournaments")
                        .HasForeignKey("WinnerTeamId");

                    b.Navigation("WinnerTeam");
                });

            modelBuilder.Entity("TournamentSystem.Application.Features.Tournaments.TournamentTeam", b =>
                {
                    b.HasOne("TournamentSystem.Application.Features.Teams.Team", "Team")
                        .WithMany("TournamentTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TournamentSystem.Application.Features.Tournaments.Tournament", "Tournament")
                        .WithMany("TournamentTeams")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("TournamentSystem.Application.Features.Teams.Team", b =>
                {
                    b.Navigation("Matches");

                    b.Navigation("Players");

                    b.Navigation("TournamentTeams");

                    b.Navigation("WonTournaments");
                });

            modelBuilder.Entity("TournamentSystem.Application.Features.Tournaments.Tournament", b =>
                {
                    b.Navigation("Matches");

                    b.Navigation("TournamentTeams");
                });
#pragma warning restore 612, 618
        }
    }
}