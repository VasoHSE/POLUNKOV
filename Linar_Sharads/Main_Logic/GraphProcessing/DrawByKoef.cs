using System.Collections.Generic;

namespace Main_Logic.GraphProcessing
{
   public class DrawByKoef
    {
        //Repository repository = new Repository();        
        // var sfs = repository.GetKoefs(repository.MakeQuery(repository.GetApiString()));


        
        
        public DrawByKoef()
        {
           
            var repository = new Repository();
            //_k = repository.GetKoefs(repository.MakeQuery(repository.GetApiString()));           
        }


        public  List<double[]> Xykoef()
        {
            var points = GetUserGraphUnfoInfo.Pointamount;
            var x = new double[points];
            var y = new double[points];
            x[0] = 0;
            var dx = 10;
            for (int i = 0; i < x.Length; i++)
            {
                x[i] =-( x[0] + i * dx);
            }
            y[0] = 0;
            for (int i = 1; i < y.Length; i++)
            {
                y[i] = y[i - 1] + (_k[i - 1] /** 10000*/) * dx;
            }
           return new List<double[]> { x, y };
        }




    }
}
