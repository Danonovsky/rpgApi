﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rpg.DAO;

namespace rpg.DAO.Migrations
{
    [DbContext(typeof(RpgContext))]
    [Migration("20211208200612_AddRaceToCharacter")]
    partial class AddRaceToCharacter
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("rpg.DAO.Models.Character.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CampaignId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CampaignPlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Race")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("rpg.DAO.Models.Character.Characteristic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Advancement")
                        .HasColumnType("int");

                    b.Property<Guid>("CharacterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Characteristics");
                });

            modelBuilder.Entity("rpg.DAO.Models.Character.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Advancement")
                        .HasColumnType("int");

                    b.Property<Guid>("CharacterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("rpg.DAO.Models.Game.Campaign", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("System")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("rpg.DAO.Models.Game.CampaignPlayer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CampaignId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CharacterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("CharacterId")
                        .IsUnique()
                        .HasFilter("[CharacterId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("CampaignPlayers");
                });

            modelBuilder.Entity("rpg.DAO.Models.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("rpg.DAO.Models.Character.Character", b =>
                {
                    b.HasOne("rpg.DAO.Models.Game.Campaign", "Campaign")
                        .WithMany()
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("rpg.DAO.Models.Character.Characteristic", b =>
                {
                    b.HasOne("rpg.DAO.Models.Character.Character", "Character")
                        .WithMany("Characteristics")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("rpg.DAO.Models.Character.Skill", b =>
                {
                    b.HasOne("rpg.DAO.Models.Character.Character", "Character")
                        .WithMany("Skills")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("rpg.DAO.Models.Game.Campaign", b =>
                {
                    b.HasOne("rpg.DAO.Models.User.User", "User")
                        .WithMany("Campaigns")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("rpg.DAO.Models.Game.CampaignPlayer", b =>
                {
                    b.HasOne("rpg.DAO.Models.Game.Campaign", "Campaign")
                        .WithMany("CampaignPlayers")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("rpg.DAO.Models.Character.Character", "Character")
                        .WithOne("CampaignPlayer")
                        .HasForeignKey("rpg.DAO.Models.Game.CampaignPlayer", "CharacterId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("rpg.DAO.Models.User.User", "User")
                        .WithMany("CampaignPlayers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("Character");

                    b.Navigation("User");
                });

            modelBuilder.Entity("rpg.DAO.Models.Character.Character", b =>
                {
                    b.Navigation("CampaignPlayer");

                    b.Navigation("Characteristics");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("rpg.DAO.Models.Game.Campaign", b =>
                {
                    b.Navigation("CampaignPlayers");
                });

            modelBuilder.Entity("rpg.DAO.Models.User.User", b =>
                {
                    b.Navigation("CampaignPlayers");

                    b.Navigation("Campaigns");
                });
#pragma warning restore 612, 618
        }
    }
}
