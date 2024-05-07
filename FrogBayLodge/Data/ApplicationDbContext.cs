using Microsoft.EntityFrameworkCore;
using FrogBayLodge.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Humanizer;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;
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
                new Room { Id=1, Name= "Toad Suite", Beds = 4, BedType = "1 King 2 Queens 1 Pullout", MaximumOccupancy=8, Kitchenette=true, Fireplace=true,View=true, BasePrice=300.00},
                new Room { Id = 2, Name = "Tadpole 101", Beds = 2,  BedType = "2 Queens", MaximumOccupancy = 4, Kitchenette = false, Fireplace = false, View = false, BasePrice = 100.00 },
                new Room { Id = 3, Name = "Tadpole 102", Beds = 2, BedType = "2 Queens", MaximumOccupancy = 4, Kitchenette = true, Fireplace = false, View = false, BasePrice = 120.00 },
                new Room { Id = 4, Name = "Frog 103", Beds = 1, BedType = "1 King", MaximumOccupancy = 2, Kitchenette = true, Fireplace = true, View = false, BasePrice = 180.00 }
                );
            modelBuilder.Entity<Spa>().HasData(
                new Spa { Id = 1, Package = "Swedish Massage", Price = 150.00, Description = "Experience the ultimate relaxation with a Swedish massage, known for its gentle yet effective techniques that soothe muscles and promote circulation. Enjoy a blissful escape from stress and tension as skilled hands knead away knots, leaving you feeling rejuvenated and refreshed." },
           
                new Spa { Id = 2, Package = "Deep Tissue Massage", Price = 180.00, Description = "Dive deep into muscle tension and knots with a deep tissue massage, designed to target chronic pain and tightness.Through firm pressure and slow strokes, this treatment reaches the deeper layers of muscles, releasing tension and restoring mobility for a renewed sense of well - being." },
            
               new Spa { Id = 3, Package = "Diamond Glow Facial", Price = 130.00, Description = " Reveal your skin's natural radiance with the Diamond Glow facial, a luxurious treatment that exfoliates, extracts, and infuses the skin with nourishing serums. Using diamond-tipped technology, this non-invasive procedure gently buffs away dead skin cells, leaving your complexion smoother, brighter, and more youthful-looking." },

               new Spa { Id = 4, Package = "Frog Peel Facial", Price = 140.00, Description = "Renew your skin with the transformative Frog Peel facial, featuring a potent blend of exfoliating acids to rejuvenate and clarify the complexion. This advanced peel helps to diminish fine lines, acne scars, and hyperpigmentation, revealing smoother, more even-toned skin with a healthy glow." }
            );
        }
        public DbSet<FrogBayLodge.Models.Spa> Spa { get; set; } = default!;
      
    }
}

//Note: Spa descriptions are from OpenAI. OpenAI. (2024). Spa treatments short descriptions [Description]. OpenAI. https://openai.com