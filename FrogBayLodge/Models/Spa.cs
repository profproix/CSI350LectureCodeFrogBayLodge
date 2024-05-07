using System.ComponentModel.DataAnnotations;

namespace FrogBayLodge.Models
{
    public class Spa
    {

        [Key]
        public int Id { get; set; }
        public string Package { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
