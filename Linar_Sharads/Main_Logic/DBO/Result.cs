using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Main_Logic.DBO
{
    internal class Result
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string Describtion { get; set; }
        //Not Required
        public Area Area { get; set; }

        [Required]
        public float StartValue { get; set; }
        [Required]
        public float EndValue { get; set; }
        [MaxLength(25), Required]
        public List<float> Koeficients { get; set; }
        //Many to Many
        public List<LineGraph> LineGraphs { get; set; }
    }
}
