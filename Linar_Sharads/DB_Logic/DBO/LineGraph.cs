using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Main_Logic.DBO
{
    internal class LineGraph
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Area Area { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string Describtion { get; set; }
        [MaxLength(256), Required]  
        public string WebQuery { get; set; }
        // if plot without WebQuery
        //[Required]
        //public float StartValue { get; set; }   
        //[Required]
        //public float EndValue { get; set; }
        [MaxLength(25),Required]
        public List<float> Koeficients { get; set; }
        //Many to Many
        public List<Result> Results { get; set; }
    }
}
