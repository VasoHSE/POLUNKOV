using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Main_Logic.Api
{
   public class Request
    {
        [JsonProperty("dataset")]
        public Dataset dataset { get; set; }
    }
}
