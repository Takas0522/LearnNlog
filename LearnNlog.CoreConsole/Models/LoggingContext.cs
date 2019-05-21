using System;
using LearnNlog.Logging.EntityFrameworkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LearnNlog.CoreConsole.Models
{
    public partial class LoggingContext : DbContext
    {
        public LoggingContext()
        {
        }

        public LoggingContext(DbContextOptions<LoggingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LoggingTable> LoggingTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Logging;Integrated Security=True;");
            }
            var fact = new EntityFrameworkLogger();
            optionsBuilder.UseLoggerFactory(fact.GetLoggerFactory());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<LoggingTable>(entity =>
            {
                entity.HasIndex(e => new { e.Logged, e.Level })
                    .HasName("IX_LoggingTable_Column");

                entity.Property(e => e.ActionMethod).HasMaxLength(250);

                entity.Property(e => e.Application)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Logger).HasMaxLength(250);

                entity.Property(e => e.Message).IsRequired();
            });
        }
    }
}
