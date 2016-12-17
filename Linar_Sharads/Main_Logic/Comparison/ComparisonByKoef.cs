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
        public IEnumerable<DATAResult> Compare(List<float> listOfKoefs)
        {
            var positive = listOfKoefs.Count(t => t >= 0);
            var negative = listOfKoefs.Count(t => t < 0);

            var c = new Context();

            var selected =
                c.LineGraph.Where(
                    t =>
                        t.Positives == positive&&
                        t.Negatives == negative).ToList().ToList();

            if (selected == null)
                throw new ArgumentException("There is nothing similar");

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
                suitable.Add(key++,ListOfKoefFromDB);
                ListOfKoefFromDB.Clear();
            }

            var temp = 0;
            foreach (var oneListOfKoef in suitable)
            {
                for (var i = 0; i < listOfKoefs.Count; i++)
                {
                    if (Math.Abs(listOfKoefs[i] - oneListOfKoef.Value[i]) <= 0.5)
                        temp += 1;                    
                }
                suitable1.Add(oneListOfKoef.Key,temp);
            }

            suitable1 = suitable1.OrderBy(t => t.Value) as Dictionary<int, int>;

            var selectedObjects = new List<DATAResult>();

            foreach (var item in suitable1)
            {
               selectedObjects.Add(new DATAResult { Name = selected[item.Key-1].Name, Description = selected[item.Key - 1].Describtion, Link = selected[item.Key - 1].WebQuery });
               if (selectedObjects.Count==10)
                    break;
            }


            return selectedObjects;

        }
    }
}
