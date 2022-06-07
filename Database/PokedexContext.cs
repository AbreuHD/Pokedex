using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class PokedexContext : DbContext
    {
        public PokedexContext(DbContextOptions<PokedexContext> options) : base(options) { }

        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Region> Regiones { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API

            #region "Datatables Names"
            modelBuilder.Entity<Tipo>().ToTable("Tipos");
            modelBuilder.Entity<Region>().ToTable("Regiones");
            modelBuilder.Entity<Pokemon>().ToTable("Pokemons");
            #endregion

            #region "primary keys"
            modelBuilder.Entity<Tipo>().HasKey(Tipo => Tipo.Id);
            modelBuilder.Entity<Region>().HasKey(Region => Region.Id);
            modelBuilder.Entity<Pokemon>().HasKey(Pokemon => Pokemon.Id);
            #endregion

            #region "Relationships"
            modelBuilder.Entity<Region>().HasMany<Pokemon>(Region => Region.Pokemon)
                .WithOne(Pokemon => Pokemon.Region).HasForeignKey(Pokemon => Pokemon.RegionId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tipo>().HasMany<Pokemon>(Tipo => Tipo.Pokemon)
                .WithOne(Pokemon => Pokemon.Tipo).HasForeignKey(Pokemon => Pokemon.Id).OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region "Property Configurations"
            modelBuilder.Entity<Tipo>().Property(Tipo => Tipo.Name).IsRequired();

            modelBuilder.Entity<Region>().Property(Region => Region.Name).IsRequired();

            modelBuilder.Entity<Pokemon>().Property(Pokemon => Pokemon.Name).IsRequired();
            modelBuilder.Entity<Pokemon>().Property(Pokemon => Pokemon.ImgUrl).IsRequired();
            modelBuilder.Entity<Pokemon>().Property(Pokemon => Pokemon.RegionId).IsRequired();
            modelBuilder.Entity<Pokemon>().Property(Pokemon => Pokemon.TipoId).IsRequired();
            #endregion
        }
    }
}
