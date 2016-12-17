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
        public DATAResult Compare(List<float> listOfKoefs)
        {
            var positive = listOfKoefs.Count(t => t >= 0);
            var negative = listOfKoefs.Count(t => t < 0);

            var c = new Context();

            var selected =
                c.LineGraph.Where(
                    t =>
                        Math.Abs(t.Positives - positive) == 0 &&
                        Math.Abs(t.Negatives - negative) == 0).ToList();
            //.OrderBy(t => Math.Abs(t.Positives - positive.Count()))
            //.ThenBy(t => Math.Abs(t.Negatives - negative.Count()));


            if (selected == null)
                throw new ArgumentException("There is nothing similar");

            var ListOfKoefFromDB = new List<float>();

            foreach (var item in selected)
            {
                foreach (var innerItem in item.Koeficients.Split(new [] {';'},StringSplitOptions.RemoveEmptyEntries))
                {
                    ListOfKoefFromDB.Add(float.Parse(innerItem));
                }
                break;
            }

            var temp = 0;

            for (var i = 0; i < listOfKoefs.Count; i++)
            {
                if (Math.Abs(listOfKoefs[i] - ListOfKoefFromDB[i]) <= 10)
                    temp += 1;
                else
                {
                    break;
                }
            }

            if (temp>=2)
            {
                return
                selected.Select(t => new DATAResult { Name = t.Name, Description = t.Describtion, Link = t.WebQuery })
                    .First();
            }
            else
            {
                   throw  new ArgumentException();
                
            }

            
        }
    }
}
