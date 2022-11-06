using AppTest7.Models;
using Microsoft.EntityFrameworkCore;

namespace AppTest7.Data
{
    public class DalContext : DbContext
    {
        public DalContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Todo>? Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().ToTable("Todo");
        }
    }
}