using Microsoft.EntityFrameworkCore;
using szakmai_eb.Models;

namespace szakmai_eb.Data
{
    public class EuroskillsContext : DbContext
    {
        public EuroskillsContext(DbContextOptions<EuroskillsContext> options) : base(options) { }

        public DbSet<Szakma> Szakmak { get; set; }
        public DbSet<Orszag> Orszagok { get; set; }
        public DbSet<Versenyzo> Versenyzok { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Szakma>().ToTable("szakma");
            modelBuilder.Entity<Orszag>().ToTable("orszag");
            modelBuilder.Entity<Versenyzo>().ToTable("versenyzo");

        }
    }
}