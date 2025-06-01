using Microsoft.EntityFrameworkCore;
using AutoShopManager.Models;
using AutoShop.Models;


namespace AutoShopManager.Data
{
    public class AutoShopContext : DbContext
    {
        public AutoShopContext(DbContextOptions<AutoShopContext> options)
            : base(options)
        {
        }

        public AutoShopContext(DbContextOptions options) : base(options)
        {
        }

        protected AutoShopContext()
        {
        }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reparacion> Reparaciones { get; set; }
        public DbSet<Partes> Partes { get; set; }
        public DbSet<Citas> Citas { get; set; }
        public DbSet <Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Citas>()
                .HasOne(c => c.Vehiculo)
                .WithMany()
                .HasForeignKey(c => c.IdVehiculo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Citas>()
                .HasOne(c => c.Cliente)
                .WithMany()
                .HasForeignKey(c => c.IdCliente)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
