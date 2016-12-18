using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Main_Logic.DTO.DTO_API;
using Main_Logic.DTO.DTO_Data;
using Main_Logic.DTO.Models;
using Newtonsoft.Json;

namespace Main_Logic
{
    public class Repository
    {
        public IEnumerable<List<DATAResult>> MakeQuery(string url)
        {
         
            using (var client = new HttpClient())
            {
                var result = client.GetStringAsync(url).Result;
                    var serializedObject = JsonConvert.DeserializeObject<ResponseOnData>(result);
                    var dataResult =
                        serializedObject.dataset.data.Select(
                            t =>
                                new DATAResult
                                {
                                    Value = float.Parse(t[1].ToString()),
                                    Link = url,
                                    Description = serializedObject.dataset.description,
                                    Name = serializedObject.dataset.name
                                });
                    if (dataResult.Count() >= 100)
                        yield return dataResult.ToList();
            }

            
        }


        public void Split<T>(List<T> array, int size, ref List<List<T>> splitedLIst)
        {
            for (var i = 0; i < GetUserGraphUnfoInfo.Pointamount; i++)
            {
                splitedLIst.Add(array.Skip(i * size).Take(size).ToList());
            }
        }

        public float DataProceeding(List<List<float>> x)
        {

            float k, b;
            GetApprox(x, out k, out b, x.Count);
            return k;
        }

        public static void GetApprox(IReadOnlyList<List<float>> x, out float k, out float b, int n)
        {
            float sumx = 0;
            float sumy = 0;
            float sumx2 = 0;
            float sumxy = 0;
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
