
using HotelModels.Data.DataGenerator;
using Microsoft.EntityFrameworkCore;
using MvvmHotel.Models;
using System.Linq;

namespace MvvmHotel.Data
{
    internal partial class HotelContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Comfort> Comforts { get; set; }
        public DbSet<Settling> Settlings { get; set; }
        public HotelContext() {
        }
        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer("Data Source=DESKTOP-Q1SG2E6\\SQLEXPRESS;Initial Catalog=MvvmHotel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<Client>()
            .Property(p => p.IsDeleted)
            .HasConversion<bool>();

            modelBuilder.Entity<Room>()
             .Property(p => p.IsDeleted)
             .HasConversion<bool>();

            modelBuilder.Entity<Settling>()
             .Property(p => p.IsDeleted)
             .HasConversion<bool>();

            var clients = ClientGenerator.GenerateClients(100).ToList();
            var rooms = RoomGenerator.GenerateRooms(100).ToList();
            var settlings = SettlingGenerator.GenerateSettlings(
               clients.Select(c => c.Id).ToList(),
               rooms.Select(c => c.Id).ToList()).ToList();

            modelBuilder.Entity<Client>().HasData(clients);
            modelBuilder.Entity<Room>().HasData(rooms);
            modelBuilder.Entity<Settling>().HasData(settlings);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
