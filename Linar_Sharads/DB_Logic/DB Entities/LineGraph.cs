using System.ComponentModel.DataAnnotations;

namespace DB_Logic.Entities
{
    public class LineGraph
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(512)]
        public string Describtion { get; set; }
        [MaxLength(256), Required]  
        public string WebQuery { get; set; }
        // if plot without WebQuery
        //[Required]
        //public float StartValue { get; set; }   
        //[Required]
        //public float EndValue { get; set; }
        [Range(0,25),Required]
        public int Positives { get; set; }
        [Range(0, 25), Required]
        public int Negatives { get; set; }
        [Required]
        public string Koeficients { get; set; }
    }
}
