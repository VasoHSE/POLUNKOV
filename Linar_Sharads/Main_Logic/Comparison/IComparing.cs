using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Logic
{
    interface IComparing<T>
    {
        IEnumerable<T> Compare(List<float> listOfKoefs);
        int K { get;  }
    }
}
