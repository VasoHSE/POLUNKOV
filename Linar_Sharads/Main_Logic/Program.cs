using Main_Logic.DTO.DTO_API;
using Main_Logic.DTO.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using DB_Logic;
using DB_Logic.DB_Entities;
using System.Windows;

namespace Main_Logic
{
    internal class Program
    {
        private Repository repo = new Repository();
        private static void Main()
        {            
            var c = new UnitOfWork("local");
            var p = new Program();
            try
            {
                p.Seed(c);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public void Seed(UnitOfWork context)
        {
            foreach (var forOneUrl in GetApisList())
            {
                float t = 0;

                foreach (var varpair in repo.MakeQuery(forOneUrl.Url))
                {
                    var dres = new DATAResult();
                    var listOfValues = new List<List<float>>();
                    foreach (var onePair in varpair)
                    {
                        dres = onePair;
                        listOfValues.Add(new List<float> { t, onePair.Value });
                        t += (float)0.05;
                    }
                    var splittedList = new List<List<List<float>>>();

                    repo.Split(listOfValues, listOfValues.Count / (GetUserGraphUnfoInfo.Pointamount-1), ref splittedList);

                    var listOfKoef = new List<float>();

                    splittedList.ForEach(n => listOfKoef.Add(repo.DataProceeding(n)));
                    context.LineGraphs.Add(new LineGraph
                    {
                        Name = dres.Name,
                        Describtion = dres.Description,
                        WebQuery = dres.Link,
                        Negatives = listOfKoef.Count(p => p < 0),
                        Positives = listOfKoef.Count(n => n >= 0),
                        Koeficients = ConvertStringArrayToString(listOfKoef)
                    });
                    context.Save();
                }
            }
        }

        private static string ConvertStringArrayToString(List<float> array)
        {
            var builder = new StringBuilder();
            foreach (var value in array)
            {
                builder.Append(value);
                builder.Append(';');
            }
            return builder.ToString();
        }

        private IEnumerable<APIResults> GetApisList()
        {
            using (var client = new HttpClient())
            {
                for (var i = 1; i < 18; i++)
                {
                    var result = client.GetStringAsync(
                        $"https://www.quandl.com/api/v3/datasets.json?database_code=BOE&per_page=100&sort_by=id&page={i}&api_key=62VyK84zgtv9d4asbz7y")
                        .Result;
                    var deserializedObject = JsonConvert.DeserializeObject<ResponseOnApi>(result);
                    var apiResults = deserializedObject.datasets.Select(t => new APIResults
                    {
                        Url =
                            $"https://www.quandl.com/api/v3/datasets/{t.database_code}/{t.dataset_code}.json?api_key=62VyK84zgtv9d4asbz7y"
                    });
                    foreach (var item in apiResults)
                        yield return item;
                }

            }
        }
    }
}

