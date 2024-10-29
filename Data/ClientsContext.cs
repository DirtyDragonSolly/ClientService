using ClientService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientService.Data
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options) : base(options) 
        { 
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Founder> Founders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Founder>().ToTable("founders");
            modelBuilder.Entity<Founder>()
                .HasOne(f => f.Client)
                .WithMany(c => c.Founders)
                .HasForeignKey(f => f.ClientId);

            modelBuilder.Entity<Client>().ToTable("clients");
        }
    }
}
