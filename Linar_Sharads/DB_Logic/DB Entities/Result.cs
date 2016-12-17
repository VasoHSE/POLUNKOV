using System.ComponentModel.DataAnnotations;

namespace DB_Logic.DB_Entities
{
    public class Result
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Describtion { get; set; }
        public byte[] Picture { get; set; }

        // if plot by Koeficients
        //[Required]
        //public float StartValue { get; set; }
        //[Required]
        //public float EndValue { get; set; }
        //[Required]
        //public string Koeficients { get; set; }

        // Graphs from local database
        public string LineGraphName { get; set; }
        public string LineGraphDescribtion { get; set; }
        [MaxLength(512), Required]
        public string LineGraphWebQuery { get; set; }
    }
}
