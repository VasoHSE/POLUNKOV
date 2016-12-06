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
    public class Repository
    {
      public   Request MakeQuery(string apiRequest)
        {
            using (var client = new HttpClient())
            {
                var result = client.GetStringAsync(apiRequest).Result;
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
                splitedLIst.Add(array.Skip(i * size).Take(size).ToList());
        }

        public List<double> GetKoefs(Request query)
        {
            var listOfValues = new List<List<double>>();
            double t = 0;
            foreach (var varpair in query.dataset.data)
            {
                listOfValues.Add(new List<double> { t, (double)varpair[1] });
                t+=0.0054;
            }

            var splittedList = new List<List<List<double>>>();

            Split(listOfValues, (int)listOfValues.Count / (GetUserGraphUnfoInfo.Pointamount-1), ref splittedList);

            var listOfKoef = new List<double>();

           splittedList.ForEach(n=> listOfKoef.Add(DataProceeding(n)));
            return listOfKoef;
        }

        public double DataProceeding(List<List<double>> x)
        {

            double k, b;
            GetApprox(x, out k, out b, x.Count);
            return k;
        }

        public static void GetApprox(IReadOnlyList<List<double>> x, out double k, out double b, int n)
        {
            double sumx = 0;
            double sumy = 0;
            double sumx2 = 0;
            double sumxy = 0;
            for (var i = 0; i < n; i++)
            {
                sumx += x[i][0];
                sumy += x[i][1];
                sumx2 += x[i][0] * x[i][0];
                sumxy += x[i][0] * x[i][1];
            }
            k = (n * sumxy - (sumx * sumy)) / (n * sumx2 - sumx * sumx);
            b = (sumy - k * sumx) / n;
        }
    }
}
