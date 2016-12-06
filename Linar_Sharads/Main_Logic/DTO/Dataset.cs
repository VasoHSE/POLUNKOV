using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Main_Logic.Api
{
    public class Dataset
    {
        //public int id { get; set; }
        //public string dataset_code { get; set; }
        //public string database_code { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        //public string description { get; set; }
        //public string refreshed_at { get; set; }
        //public DateTime newest_available_date { get; set; }
        //public string[] column_names { get; set; }
        //public string frequency { get; set; }
        //public string type { get; set; }
        //public DateTime oldest_available_date { get; set; }
        //public bool premium { get; set; }
        //public string column_index { get; set; }
        //public DateTime start_date { get; set; }
        //public DateTime end_date { get; set; }
        [JsonProperty("data")]
        public List<List<object>> data { get; set; }
    }
}
