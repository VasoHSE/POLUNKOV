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

        public void Split<T>(List<T> array, int size, ref List<List<T>> splitedLIst)
        {
            for (var i = 0; i < array.Count / size; i++)
            {
                splitedLIst.Add(array.Skip(i * size).Take(size).ToList());
            }
        }

        public List<double> GetKoefs(Request Query)
        {
            var approx = new Approximation();
            var listOfValues = new List<List<double>>();
            double t = 0;
            foreach (var varpair in Query.dataset.data)
            {
                listOfValues.Add(new List<double> { t, (double)varpair[1] });
                t++;
            }

            var splittedList = new List<List<List<double>>>();

            Split(listOfValues, (int)listOfValues.Count / 25, ref splittedList);

            var listOfKoef = new List<double>();
            //foreach (var item in splittedList)
            //{
            //    listOfKoef.Add(approx.DataProceeding(item));
            //}
           splittedList.ForEach(n=> listOfKoef.Add(approx.DataProceeding(n)));
            return listOfKoef;
        }
    }
}
