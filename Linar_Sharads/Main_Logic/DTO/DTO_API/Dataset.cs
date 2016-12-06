using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Logic.DTO.DTO_API
{
    class Dataset
    {
        public string dataset_code { get; set; }
        public string database_code { get; set; }
        public string name { get; set; }
        public string newest_available_date { get; set; }
        public string oldest_available_date { get; set; }
    }
}
