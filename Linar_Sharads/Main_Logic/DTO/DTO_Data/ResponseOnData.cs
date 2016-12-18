using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Main_Logic.DTO.DTO_Data
{
   public class ResponseOnData
    {
        [JsonProperty("dataset")]
        public Dataset Dataset { get; set; }
    }
}
