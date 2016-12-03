using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Main_Logic.Api;
using Newtonsoft.Json;

namespace Main_Logic
{
    class Repository
    {
        public Request MakeQuery(string apiRequest)
        {
            using (var client = new HttpClient())
            {
                string result = client.GetStringAsync(apiRequest).Result;
                return JsonConvert.DeserializeObject<Request>(result);
            }   
        }

        public string GetApiString()
        {
            return "https://www.quandl.com/api/v3/datasets/ECB/EURUSD.json?api_key=14RrJdQgDvzP-AcbYa1H";
        }
    }
}
