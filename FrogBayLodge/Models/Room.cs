using System.ComponentModel.DataAnnotations;

namespace FrogBayLodge.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Beds { get; set; }
        public string BedType { get; set; }
        [Required]
        public int MaximumOccupancy { get; set; }
        public bool? Kitchenette { get; set; }
        public bool? Fireplace { get; set; }
        public bool? View { get; set; }
        [Required]
        [Range(100, 50000)]
        public double BasePrice { get; set; }
        public string ImageUrl { get; set; } = "https://images.unsplash.com/photo-1445991842772-097fea258e7b?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D";
    }
}
