using Microsoft.EntityFrameworkCore;
using rpg.DAO.Models.Character;
using rpg.DAO.Models.Game;
using rpg.DAO.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg.DAO
{
    public class RpgContext : DbContext
    {
        public RpgContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach(var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(_ => _.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignPlayer> CampaignPlayers { get; set; }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Test> Tests { get; set; }
    }
}
