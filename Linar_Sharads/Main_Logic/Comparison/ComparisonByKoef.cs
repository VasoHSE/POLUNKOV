using System;
using System.Collections.Generic;
using System.Linq;
using DB_Logic.Repository;
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
            var positive = listOfKoefs.Where(t => t >= 0);
            var negative = listOfKoefs.Where(t => t < 0);

            var c = new LocalsqlRepository();

            var selected =
                c.GetAll().Where(
                    t =>
                        Math.Abs(t.Negatives - positive.Count()) == 0 &&
                        Math.Abs(t.Negatives - negative.Count()) == 0);
            //.OrderBy(t => Math.Abs(t.Positives - positive.Count()))
            //.ThenBy(t => Math.Abs(t.Negatives - negative.Count()));


            if (selected == null)
                throw new ArgumentException("There is nothing similar");


            return
                selected.Select(t => new DATAResult {Name = t.Name, Description = t.Describtion, Link = t.WebQuery})
                    .First();
        }
    }
}
