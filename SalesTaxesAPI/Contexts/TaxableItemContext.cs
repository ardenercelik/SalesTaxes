using System;
using SalesTaxesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace SalesTaxesAPI.Contexts
{
    public class TaxableItemContext : DbContext
    {
        public TaxableItemContext(DbContextOptions<TaxableItemContext> options)
            : base(options)
        {
        }

        public TaxableItemContext()
        {
        }

        public DbSet<TaxableItem> TaxableItems { get; set; }
        public string DbPath { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxableItem>().ToTable("TaxableItem");

            modelBuilder.Entity<TaxableItem>()
                .Property(p => p.DateCreated)
                .HasDefaultValueSql("date()")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<TaxableItem>()
                .Property(p => p.DateUpdated)
                .HasDefaultValueSql("date()")
                .ValueGeneratedOnUpdate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "TaxableItemsDatabase.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }



    }
}
