using Microsoft.EntityFrameworkCore;
using FrogBayLodge.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace FrogBayLodge.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Room> Rooms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Note: Needed to avoid a primary key error when we intall Identity Framework
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Room>().HasData(
                new Room { Id=1, Name= "Toad Suite", Beds="1 King 2 Queens 1 Pullout", MaximumOccupancy=8, Kitchenette=true, Fireplace=true,View=true, BasePrice=300.00},
                new Room { Id = 2, Name = "Tadpole 101", Beds = "2 Queens", MaximumOccupancy = 4, Kitchenette = false, Fireplace = false, View = false, BasePrice = 100.00 },
                new Room { Id = 3, Name = "Tadpole 102", Beds = "2 Queens", MaximumOccupancy = 4, Kitchenette = true, Fireplace = false, View = false, BasePrice = 120.00 },
                new Room { Id = 4, Name = "Frog 103", Beds = "1 King", MaximumOccupancy = 2, Kitchenette = true, Fireplace = true, View = false, BasePrice = 180.00 }
                );
       

        }
    }
}
