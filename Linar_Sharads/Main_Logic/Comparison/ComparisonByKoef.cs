using System;
using System.Collections.Generic;
using System.Linq;
using DB_Logic;
using Main_Logic.DTO.Models;

namespace Main_Logic.Comparison
{
    class ComparisonByKoef : IComparing<DataResult>
    {
        public IEnumerable<DataResult> Compare(List<float> listOfKoefs)
        {
            var positive = listOfKoefs.Count(t => t >= 0);
            var negative = listOfKoefs.Count(t => t < 0);

            var c = new UnitOfWork("local");

            var selected =
                c.LineGraphs.GetAll().Where(
                    t =>
                        t.Positives == positive&&
                        t.Negatives == negative).ToList().ToList();

            if (selected == null)
                throw new ArgumentException("There is nothing similar");

            var listOfKoefFromDb = new List<float>();
            var key = 0;
            var suitable1 = new Dictionary<int,int>();
            var suitable = new Dictionary<int,List<float>>();
            foreach (var item in selected)
            {
                foreach (var innerItem in item.Koeficients.Split(new [] {';'},StringSplitOptions.RemoveEmptyEntries))
                    listOfKoefFromDb.Add(float.Parse(innerItem));  
                suitable.Add(key++,new List<float>(listOfKoefFromDb));
                listOfKoefFromDb.Clear();
            }

            
            foreach (var oneListOfKoef in suitable)
            {
                var temp = listOfKoefs.Where((t, i) => Math.Abs(t - oneListOfKoef.Value[i]) <= 1).Count();
                suitable1.Add(oneListOfKoef.Key,temp);
            }

            suitable1 = suitable1.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

            var selectedObjects = new List<DataResult>();

            var kek = suitable1.GroupBy(i => i.Value).First();





            //foreach (var item in suitable1)
            //{
            //   selectedObjects.Add(new DATAResult { Name = selected[item.Key].Name, Description = selected[item.Key].Describtion, Link = selected[item.Key].WebQuery });
            //   if (selectedObjects.Count==10)
            //        break;
            //}

            foreach (var item in kek)
            {
                
                    
                        selectedObjects.Add(new DataResult { Name = selected[item.Key].Name, Description = selected[item.Key].Describtion, Link = selected[item.Key].WebQuery });
                        if (selectedObjects.Count == 10)
                            break;
                    
               
            }




            return selectedObjects;

        }
    }
}
