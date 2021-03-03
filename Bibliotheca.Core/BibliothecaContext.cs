using Bibliotheca.Core.Tables;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bibliotheca.Core
{
    public class BibliothecaContext : DbContext
    {
        public DbSet<BookTable> Books { get; set; }
        public DbSet<AccountTable> Accounts { get; set; }

        public const string DefaultSchema = "dbo";
        private readonly string connectionString;

        public BibliothecaContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public static BibliothecaContext CreateContext()
        {
            return new BibliothecaContext(Settings.ConnectionString);
        }
        public BibliothecaContext(DbContextOptions options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite(connectionString,
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory", DefaultSchema));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DefaultSchema);

            modelBuilder.Entity<BookTable>().HasIndex(x => x.Status);

            modelBuilder.Entity<BookTable>()
                .HasOne(a => a.Account)
                .WithMany(b => b.Books);

            base.OnModelCreating(modelBuilder);
        }
    }
}
