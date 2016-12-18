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
                if (dataResult.Count()>=200)
                {
                    yield return dataResult.ToList();
                }
                
            }
        }


        //public IEnumerable<APIResults> GetApisList()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        for (var i = 1; i < 18; i++)
        //        {
        //            var result = client.GetStringAsync(
        //                $"https://www.quandl.com/api/v3/datasets.json?database_code=BOE&per_page=100&sort_by=id&page={i}&api_key=14RrJdQgDvzP-AcbYa1H")
        //                .Result;
        //            var deserializedObject = JsonConvert.DeserializeObject<ResponseOnApi>(result);
        //            var apiResults = deserializedObject.datasets.Select(t => new APIResults
        //            {
        //                Url =
        //                    $"https://www.quandl.com/api/v3/datasets/{t.database_code}/{t.dataset_code}.json?api_key=14RrJdQgDvzP-AcbYa1H"
        //            });
        //            foreach (var item in apiResults)
        //            {
        //                yield return item;
        //            }
        //        }

        //    }
        //}

        public void Split<T>(List<T> array, int size, ref List<List<T>> splitedLIst)
        {
            for (var i = 0; i < GetUserGraphUnfoInfo.Pointamount; i++)
            {
                splitedLIst.Add(array.Skip(i * size).Take(size).ToList());
            }
        }

        //public IEnumerable<List<float>> GetKoefs()
        //{
        //    float t = 0;
        //    foreach (var forOneUrl in GetApisList())
        //    {
        //        foreach (var varpair in MakeQuery(forOneUrl.Url))
        //        {
        //            var listOfValues = new List<List<float>>();
        //            foreach (var onePair in varpair)
        //            {
        //                listOfValues.Add(new List<float> { t, onePair.Value });
        //                t += (float)0.0054;
        //            }
        //            var splittedList = new List<List<List<float>>>();

        //            Split(listOfValues, listOfValues.Count / (GetUserGraphUnfoInfo.Pointamount-1), ref splittedList);

        //            var listOfKoef = new List<float>();

        //            splittedList.ForEach(n => listOfKoef.Add(DataProceeding(n)));
        //            yield return listOfKoef;
        //        }
        //    }

        //}

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
