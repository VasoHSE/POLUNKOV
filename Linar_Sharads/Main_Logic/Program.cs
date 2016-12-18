using Main_Logic.DTO.DTO_API;
using Main_Logic.DTO.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using DB_Logic;

namespace Main_Logic
{
    internal class Program
    {
        private static void Main()
        {
            //Test
            //using (var context = new Context())
            //{
            //    context.Database.Delete();
            //    context.Database.CreateIfNotExists();

            //    context.SaveChanges();
            //}
            //var kek = GetUserGraphUnfoInfo.KoefArray("../../../Main_Logic/image.jpeg");
            //System.Console.ReadLine();
            //Repository repository = new Repository();

            //int i = 0;
            //foreach (var item in repository.GetKoefs())
            //{
            //    Console.WriteLine(i++);
            //}
            //Console.ReadKey();
            //repo.GetKoefs();

            var c = new UnitOfWork("local");

            Program p = new Program();
            p.Seed(c);
        }

        private readonly Repository _repo = new Repository();
        public void Seed(UnitOfWork context)
        {

            foreach (var forOneUrl in GetApisList())
            {
                float t = 0;

                foreach (var varpair in _repo.MakeQuery(forOneUrl.Url))
                {
                    DataResult dres = new DataResult();
                    var listOfValues = new List<List<float>>();
                    foreach (var onePair in varpair)
                    {
                        dres = onePair;
                        listOfValues.Add(new List<float> { t, onePair.Value });
                        t += (float)0.05;
                    }
                    var splittedList = new List<List<List<float>>>();

                    _repo.Split(listOfValues, listOfValues.Count / 5, ref splittedList);

                    var listOfKoef = new List<float>();

                    splittedList.ForEach(n => listOfKoef.Add(_repo.DataProceeding(n)));
                    context.LineGraphs.Add(new DB_Logic.DB_Entities.LineGraph
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
            StringBuilder builder = new StringBuilder();
            foreach (var value in array)
            {
                builder.Append(value);
                builder.Append(';');
            }
            return builder.ToString();
        }

        private IEnumerable<ApiResults> GetApisList()
        {
            using (var client = new HttpClient())
            {
                for (var i = 1; i < 18; i++)
                {
                    var result = client.GetStringAsync(
                        $"https://www.quandl.com/api/v3/datasets.json?database_code=BOE&per_page=100&sort_by=id&page={i}&api_key=62VyK84zgtv9d4asbz7y")
                        .Result;
                    var deserializedObject = JsonConvert.DeserializeObject<ResponseOnApi>(result);
                    var apiResults = deserializedObject.Datasets.Select(t => new ApiResults
                    {
                        Url =
                            $"https://www.quandl.com/api/v3/datasets/{t.DatabaseCode}/{t.DatasetCode}.json?api_key=62VyK84zgtv9d4asbz7y"
                    });
                    foreach (var item in apiResults)
                    {
                        yield return item;
                    }
                }

            }
        }
    }
}

