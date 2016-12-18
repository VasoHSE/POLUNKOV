using Newtonsoft.Json;

namespace Main_Logic.DTO.DTO_API
{
    class ResponseOnApi
    {
        [JsonProperty("datasets")]
        public Dataset[] Datasets { get; set; }
    }
}
