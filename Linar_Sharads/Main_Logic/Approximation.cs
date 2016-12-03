using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Logic
{
    internal class Approximation
    {
        public double DataProceeding(List<List<double>> x)
        {
            
            double k, b;
            GetApprox(x, out k, out b, x.Count);
            return k;
        }

        public static void GetApprox(IReadOnlyList<List<double>> x, out double k, out double b, int n)
        {
            double sumx = 0;
            double sumy = 0;
            double sumx2 = 0;
            double sumxy = 0;
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
