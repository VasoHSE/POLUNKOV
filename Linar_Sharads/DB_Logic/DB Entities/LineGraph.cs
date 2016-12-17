using System.ComponentModel.DataAnnotations;

namespace DB_Logic.DB_Entities
{
    public class LineGraph
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Describtion { get; set; }
        [MaxLength(512), Required]  
        public string WebQuery { get; set; }

        // For comparison
        [Range(0,25),Required]
        public int Positives { get; set; }
        [Range(0, 25), Required]
        public int Negatives { get; set; }
        [Required]
        public string Koeficients { get; set; }
    }
}
