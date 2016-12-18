using System.Collections.Generic;

namespace Main_Logic.Comparison
{
    internal interface IComparing<out T>
    {
        IEnumerable<T> Compare(List<float> listOfKoefs);
        int K { get;  }
    }
}
