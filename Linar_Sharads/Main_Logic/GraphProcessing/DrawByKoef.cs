using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Logic
{
   public class DrawByKoef
    {
        //Repository repository = new Repository();        
        // var sfs = repository.GetKoefs(repository.MakeQuery(repository.GetApiString()));


        
        List<double> _k;
        public DrawByKoef()
        {
           
            Repository repository = new Repository();
            //_k = repository.GetKoefs(repository.MakeQuery(repository.GetApiString()));           
        }


        public  List<double[]> XYKOEF()
        {
            var points = GetUserGraphUnfoInfo.Pointamount;
            var X = new double[points];
            var Y = new double[points];
            X[0] = 0;
            var dx = 10;
            for (int i = 0; i < X.Length; i++)
            {
                X[i] =-( X[0] + i * dx);
            }
            Y[0] = 0;
            for (int i = 1; i < Y.Length; i++)
            {
                Y[i] = Y[i - 1] + (_k[i - 1] /** 10000*/) * dx;
            }
           return new List<double[]> { X, Y };
        }




    }
}
