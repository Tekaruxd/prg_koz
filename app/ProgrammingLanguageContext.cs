using System;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProgrammingLanguagesDatabase.Models;

namespace ProgrammingLanguagesDatabase.Data
{
    public class ProgrammingLanguageContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<CreatedBy> CreatedBy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "Server=localhost;Database=plang;User=root;Password=;",
                new MySqlServerVersion(new Version(8, 0, 26))
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreatedBy>()
                .HasOne(cb => cb.Language)
                .WithMany()
                .HasForeignKey(cb => cb.LanguageId);

            modelBuilder.Entity<CreatedBy>()
                .HasOne(cb => cb.Author)
                .WithMany()
                .HasForeignKey(cb => cb.AuthorId);

            modelBuilder.Entity<Language>()
            .HasMany(l => l.CreatedBy)
            .WithOne(cb => cb.Language)
            .HasForeignKey(cb => cb.LanguageId);

            modelBuilder.Entity<Author>()
            .HasMany(a => a.CreatedBy)
            .WithOne(cb => cb.Author)
            .HasForeignKey(cb => cb.AuthorId);

            modelBuilder.HasDefaultSchema("plang");
        }
    }
}
