using System.ComponentModel.DataAnnotations;

namespace Main_Logic.Entities
{
    public class LineGraph
    {
        [Key]
        public int Id { get; set; }
        
        
        public string Name { get; set; }
        
        public string Describtion { get; set; }
         
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
