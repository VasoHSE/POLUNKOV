using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Main_Logic
{
    class GetUserGraphUnfoInfo
    {
        public List<int[]> Go()
        {
           
            var imageArray = ImageConvert("../../image.png");
            var kek = FindXY(imageArray);
            return kek;
        }


        public static int[][] ImageConvert(string path) //Convert bitmap to double array with 1 and 0
        {
            var bitmap = new Bitmap(path);

            var imgArray = new int[bitmap.Width][];
            for (int i = 0; i < imgArray.Length; i++)
            {
                imgArray[i] = new int[bitmap.Height];
            }

            var white = Color.White.ToArgb();
            for (var i = 0; i < bitmap.Width; ++i)
            {
                for (var j = 0; j < bitmap.Height; ++j)
                {
                    var pixelCol = bitmap.GetPixel(i, j);
                    if (pixelCol.ToArgb() == white)
                    {
                        imgArray[i][j] = 0;
                    }
                    else
                    {
                        imgArray[i][j] = 1;
                    }
                }
            }
            return imgArray;
        }

        //lets say the step is 1/40 length     

        public static int Pointamount
        {            get
            {
                return 40;
            }            
        }

        public static List<int[]> FindXY(int[][] imgArray) //arrays of Xi & Yi
        {
            
            int xn = 0;//last x
            var xar = imgArray.Length;
            var yar = imgArray[1].Length;
            for (int i = 0; i < xar; i++)
            {
                for (int j = 0; j < yar; j++)
                {
                    if (imgArray[i][j] == 1)
                    {
                        xn = i;
                        break;
                    }

                }

            }
            int x1 = 0;//first x
            for (int i = xar - 1; i > 0; i--)
            {
                for (int j = 0; j < yar; j++)
                {
                    if (imgArray[i][j] == 1)
                    {
                        x1 = i;
                        break;
                    }
                }
            }

            
           
            var X = new int[Pointamount];
            var Y = new int[Pointamount];
            var dx = (int)((xn - x1) / (Pointamount - 1));//step
            int a = 0;
            int i1 = x1;
            int j1 = 0;
            do// find Xi Yi arrays
            {

                if (imgArray[i1][j1] == 1)
                {
                    X[a] = i1;
                    Y[a] = -j1;
                    a++;
                    i1 += dx;
                    j1 = 0;
                }
                j1++;
            } while (i1 < x1 + (Pointamount - 1) * dx + 1);




            var kek = new List<int[]>();
            kek.Add(X);
            kek.Add(Y);
            return kek;

        }
        public static double[] KoefArray(List<int[]> plot) //Array of Ki
        {
            int[] X = plot[0];
            int[] Y = plot[1];
            double[] K = new double[Pointamount - 1];
            for (int i = 0; i < (Pointamount - 1); i++)
            {
                K[i] = Math.Round((double)(Y[i + 1] - Y[i]) / (double)(X[i + 1] - X[i]), 2);
            }
            return K;
        }
    }
}
