using System.ComponentModel.DataAnnotations;

namespace Main_Logic.DBO
{
    internal class Area
    {       
        [Key, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Describtion { get; set; }
    }
}
