using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Main_Logic.DTO.DTO_API;
using Main_Logic.DTO.DTO_Data;
using Main_Logic.DTO.Models;
using Newtonsoft.Json;

namespace Main_Logic
{
    public class Repository
    {
      public IEnumerable<List<DATAResult>> MakeQuery()
      {
          var listOfData = new List<List<DATAResult>>();
          using (var client = new HttpClient())
          {
              foreach (var item in GetApisList())
              {
                  //var listForOneUrl = new List<DATAResult>();
                  var result = client.GetStringAsync(item.Url).Result;
                  var serializedObject = JsonConvert.DeserializeObject<ResponseOnData>(result);
                  var dataResult =
                      serializedObject.dataset.data.Select(
                          t =>
                              new DATAResult
                              {
                                  Value = (double) t[1],
                                  Link = item.Url,
                                  Description = serializedObject.dataset.name
                              });
                    //listForOneUrl.AddRange(dataResult);
                    listOfData.Add(dataResult.ToList());
              }
          }
          foreach (var item in listOfData)
          {
              yield return item;
          }

        }

        public IEnumerable<APIResults> GetApisList()
        {
            var apisList = new List<APIResults>();
            using (var client = new HttpClient())
            {
                for (int i = 1; i < 18; i++)
                {
                    var result = client.GetStringAsync(
                        $"https://www.quandl.com/api/v3/datasets.json?database_code=BOE&per_page=100&sort_by=id&page={i}&api_key=14RrJdQgDvzP-AcbYa1H")
                        .Result;
                    var deserializedObject = JsonConvert.DeserializeObject<ResponseOnApi>(result);
                    var apiResults = deserializedObject.datasets.Select(t => new APIResults
                    {
                        Url =
                            $"https://www.quandl.com/api/v3/datasets/{t.database_code}/{t.dataset_code}.json?api_key=14RrJdQgDvzP-AcbYa1H"
                    });
                    apisList.AddRange(apiResults);

                }
                
            }
            foreach (var resultse in apisList)
            {
                yield return resultse;
            }
        }

        public void Split<T>(List<T> array, int size, ref List<List<T>> splitedLIst)
        {
            for (var i = 0; i < array.Count / size; i++)
                splitedLIst.Add(array.Skip(i * size).Take(size).ToList());
        }

        public IEnumerable<List<double>> GetKoefs()
        {            
            double t = 0;
            foreach (var forOneUrl in MakeQuery())
            {
                var listOfValues = new List<List<double>>();
                foreach (var varpair in forOneUrl)
                {
                    listOfValues.Add(new List<double> { t, varpair.Value});
                    t += 0.0054;
                }
                var splittedList = new List<List<List<double>>>();

                Split(listOfValues, (int)listOfValues.Count / (GetUserGraphUnfoInfo.Pointamount - 1), ref splittedList);

                var listOfKoef = new List<double>();

                splittedList.ForEach(n => listOfKoef.Add(DataProceeding(n)));
                yield return listOfKoef;
            }

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
