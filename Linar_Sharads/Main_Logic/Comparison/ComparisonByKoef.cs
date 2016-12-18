using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Logic;
using Main_Logic.DTO.Models;

namespace Main_Logic
{
    class ComparisonByKoef : IComparing<DATAResult>
    {
        public int K { get; set; }

        public IEnumerable<DATAResult> Compare(List<float> listOfKoefs)
        {

            var positive = listOfKoefs.Count(t => t >= 0);
            var negative = listOfKoefs.Count(t => t < 0);

            var c = new UnitOfWork("local");

                var selected =
                    c.LineGraphs.GetAll().Where(
                        t =>
                            t.Positives == positive &&
                            t.Negatives == negative).ToList().ToList();

            if (selected.Count == 0)
                throw new ArgumentException("There is noting similar");

            var ListOfKoefFromDB = new List<float>();
            var listOfLists = new List<List<float>>();
            var key = 0;
            var suitable1 = new Dictionary<int,int>();
            var suitable = new Dictionary<int,List<float>>();
            foreach (var item in selected)
            {
                foreach (var innerItem in item.Koeficients.Split(new [] {';'},StringSplitOptions.RemoveEmptyEntries))
                {
                    ListOfKoefFromDB.Add(float.Parse(innerItem));  
                }
                listOfLists.Add(ListOfKoefFromDB);
                suitable.Add(key++,new List<float>(ListOfKoefFromDB));
                ListOfKoefFromDB.Clear();
            }

            
            foreach (var oneListOfKoef in suitable)
            {
                var temp = 0;
                for (var i = 0; i < listOfKoefs.Count; i++)
                {
                    if (Math.Abs(listOfKoefs[i] - oneListOfKoef.Value[i]) <= 1)
                        temp += 1;                    
                }
                suitable1.Add(oneListOfKoef.Key,temp);
            }

            suitable1 = suitable1.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

            var selectedObjects = new List<DATAResult>();
            K = suitable1.Values.Max();
            if (K == 0)
                throw new ArgumentException("There is nothing similar :(");
            var kek = suitable1.GroupBy(i => i.Value).First();


            foreach (var item in kek)
            {
                selectedObjects.Add(new DATAResult { Name = selected[item.Key].Name, Description = selected[item.Key].Describtion, Link = selected[item.Key].WebQuery });
                if (selectedObjects.Count == 10)
                    break;
            }

            return selectedObjects;
            
           

        }
    }
}
