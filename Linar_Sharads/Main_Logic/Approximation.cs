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
            GetApprox(x, out k, out b, 4);
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
                sumx += x[0][i];
                sumy += x[1][i];
                sumx2 += x[0][i] * x[0][i];
                sumxy += x[0][i] * x[1][i];
            }
            k = (n * sumxy - (sumx * sumy)) / (n * sumx2 - sumx * sumx);
            b = (sumy - k * sumx) / n;
        }
    }
}
