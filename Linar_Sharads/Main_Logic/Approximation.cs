using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Logic
{
    internal class Approximation
    {
        private void DataProceeding(string[] args)
        {
            var x = new double[2][];
            double k, b;
            // values should be inserted from dataset
            x[0] = new[] { 2.00, 5.18, 7.23, 8.1 };
            x[1] = new[] { 1.00, 2.00, 3.00, 4.00, 1.5 };
            GetApprox(x, out k, out b, 4);
        }

        public static void GetApprox(IReadOnlyList<double[]> x, out double k, out double b, int n)
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
