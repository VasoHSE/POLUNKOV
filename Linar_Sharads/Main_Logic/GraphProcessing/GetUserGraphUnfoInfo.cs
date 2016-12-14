using System;
using System.Collections.Generic;
using System.Drawing;

namespace Main_Logic
{
    public class GetUserGraphUnfoInfo
    {
        //lets say the step is 1/25 length    
        public static int Pointamount => 25;
        public  int X0 => FindXY(_path)[0][0];
        public  double[] KfcArray => KoefArray(_path);
        public  int StepX=> (FindXY(_path)[0][0] + FindXY(_path)[0][FindXY(_path)[0].Length - 1]) / (Pointamount - 1);
        //private  string _path => "../../../Main_Logic/image.jpeg";


        private string _path;
        public GetUserGraphUnfoInfo()
        {
            this._path = "../../../Main_Logic/image.jpeg";
        }

        public static int[][] ImageConvert(string path) //Convert bitmap to double array with 1 and 0
        {
            var bitmap = new Bitmap(path);
            var imgArray = new int[bitmap.Width][];
            for (var i = 0; i < imgArray.Length; i++)
                imgArray[i] = new int[bitmap.Height];
            var black = Color.Black.ToArgb();
            for (var i = 0; i < bitmap.Width; ++i)
                for (var j = 0; j < bitmap.Height; ++j)
                {
                    var pixelCol = bitmap.GetPixel(i, j);
                    if (pixelCol.ToArgb() == black)
                        imgArray[i][j] = 0;
                    else
                        imgArray[i][j] = 1;
                }
            return imgArray;
        }      

           

        public static List<int[]> FindXY(string path) //arrays of Xi & Yi
        {
            
            var imgArray = ImageConvert(path);
            var xn = 0; //last x
            var xar = imgArray.Length;
            var yar = imgArray[1].Length;
            for (var i = 0; i < xar; i++)
                for (var j = 0; j < yar; j++)
                {
                    if (imgArray[i][j] != 1) continue;
                    xn = i;
                    break;
                }
            var x1 = 0; //first x
            for (var i = xar - 1; i > 0; i--)
                for (var j = 0; j < yar; j++)
                {
                    if (imgArray[i][j] != 1) continue;
                    x1 = i;
                    break;
                }
            var x = new int[Pointamount];
            var y = new int[Pointamount];
            var dx = (int) ((xn - x1)/(Pointamount - 1)); //step
            if (dx == 0)
                throw new ArgumentException("Requiring longer function");
            var a = 0;
            var i1 = x1;
            var j1 = 0;
            try
            {
                do // find Xi Yi arrays
                {
                    if (imgArray[i1][j1] == 1)
                    {
                        x[a] = i1;
                        y[a] = -j1;
                        a++;
                        i1 += dx;
                        j1 = 0;
                    }
                    j1++;
                } while (i1 < x1 + (Pointamount - 1)*dx + 1);
            }
            catch
            {
                throw new ArgumentException("Choose a continuous function");
            }

            var kek = new List<int[]> {x, y};
            return kek;
        }

        public static double[] KoefArray(string path) //Array of Ki
        {
            var plot = FindXY(path);
            var x = plot[0];
            var y = plot[1];
            var k = new double[Pointamount - 1];
            for (var i = 0; i < Pointamount - 1; i++)
                k[i] = Math.Round((double) (y[i + 1] - y[i])/(double) (x[i + 1] - x[i]), 2);
            return k;
        }
    }
}
