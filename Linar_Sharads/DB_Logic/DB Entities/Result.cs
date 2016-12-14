using System.ComponentModel.DataAnnotations;

namespace DB_Logic.Entities
{
    internal class Result
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(512)]
        public string Describtion { get; set; }

        [Required]
        public float StartValue { get; set; }
        [Required]
        public float EndValue { get; set; }
        [Required]
        public string Koeficients { get; set; }

        // Graphs from local database
        [MaxLength(100)]
        public string LineGraph_Name { get; set; }
        [MaxLength(512)]
        public string Line_Graph_Describtion { get; set; }
        [MaxLength(256), Required]
        public string LineGraph_WebQuery { get; set; }
    }
}
