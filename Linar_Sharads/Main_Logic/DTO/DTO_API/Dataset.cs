using Newtonsoft.Json;

namespace Main_Logic.DTO.DTO_API
{
    class Dataset
    {
        [JsonProperty("dataset_code")]
        public string DatasetCode { get; set; }
        [JsonProperty("database_code")]
        public string DatabaseCode { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("newest_available_date")]
        public string NewestAvailableDate { get; set; }
        [JsonProperty("oldest_available_date")]
        public string OldestAvailableDate { get; set; }
    }
}
