using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data
{
    public class MyApContext : DbContext
    {
        public MyApContext(DbContextOptions<MyApContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemClient>().HasKey( ic => new
            {
                ic.ItemId,
                ic.ClientId,
                
            });

            modelBuilder.Entity<ItemClient>().HasOne(i =>i.Item).WithMany(ic => ic.ItemClients).HasForeignKey(ic => ic.ItemId);
            modelBuilder.Entity<ItemClient>().HasOne(c =>c.Client).WithMany(ic => ic.ItemClients).HasForeignKey(ic =>ic.ClientId);

            modelBuilder.Entity<Item>().HasData(
                new Item { Id= 10, Name="USB Cable", Price= 12, SerialNumberId= 1}
                );

            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber { Id = 1, Name = "usb124" , ItemId = 10}
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name="Electronics"},
                new Category { Id=2, Name="School Tools"}
                );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }  
        public DbSet<ItemClient > ItemClients { get; set; }
            
        
    }
}
