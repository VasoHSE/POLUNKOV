using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DB_Logic;
using Main_Logic.DTO.Models;

namespace Main_Logic
{
    public class GetUserGraphUnfoInfo
    {
        private int _k;
        public int K => _k;
        private IEnumerable<DATAResult> _list;
        //lets say the step is 1/25 length    
        public const int Pointamount = 6;
           
        public static string Path => "../../../Main_Logic/image.png";

        private string _path;
        public GetUserGraphUnfoInfo()
        {
            this._path = "../../../Main_Logic/image.png";
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
                    if (pixelCol == Color.FromArgb(0, 0, 0,0))
                        imgArray[i][j] = 0;
                    else
                        imgArray[i][j] = 1;
                }
            return imgArray;
        }      

        public static List<int[]> FindXy(string path) //arrays of Xi & Yi
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
            var length = xn - x1 + 1;

            var dx = (int)((xn - x1) / (Pointamount - 1)); //step
            if (dx == 0)
                throw new ArgumentException("Requiring longer function");

            var x= new int[length] ;
            var y = new int[length];
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
                        i1 ++;
                        j1 = 0;
                    }
                    j1++;
                } while (i1 < xn+1);
            }
            catch
            {
                throw new ArgumentException("Choose a continuous function");
            }

            var kek = new List<int[]> { x, y };

            return kek;


            
        }

        public IEnumerable<DATAResult> DotaForDrawing(List<List<int>> kek)
        {
            var splittedList = new List<List<List<int>>>();
            Repository repository = new Repository();
            repository.Split(kek, kek.Count / Pointamount - 1, ref splittedList);
            var listOfKoefs = new List<float>();

            foreach (var item in splittedList)
            {
                listOfKoefs.Add(repository.DataProceeding(item.Select(t => t.Select(n => (float)n).ToList()).ToList()));
            }

            IComparing<DATAResult> compare = new ComparisonByKoef();
            
           _list= compare.Compare(listOfKoefs);
            _k = compare.K;
            return _list;
        }

        public OutputModel RandomGraph(IEnumerable<DATAResult> list)
        {
            Repository repository = new Repository();
            var fromQuery = repository.MakeQuery(list.ToList()[new Random().Next(0, list.Count())].Link);
            
            var listOfKoefsForDrawing = new List<List<float>>();


            float z = 0;
            var kekl = new DATAResult();
            foreach (var item in fromQuery)
            {
                listOfKoefsForDrawing.Add(new List<float>());
                listOfKoefsForDrawing.Add(new List<float>());
               
                foreach (var innerItem in item)
                {
                    kekl = innerItem;
                    listOfKoefsForDrawing[0].Add((innerItem.Value));
                    listOfKoefsForDrawing[1].Add(z += 1);
                }

                return new OutputModel
                {                
                    Dots = listOfKoefsForDrawing,
                    Description = kekl.Description,
                    Name = kekl.Name

                };
            }
            return null;

        }


        public IEnumerable<DATAResult> EconGraphArray(List<int[]> b)
        {
            var list = new List<List<int>>();
            for (int i = 0; i < b[0].Length; i++)
            {
                list.Add(new List<int> { b[1][i],b[0][i] });
            }
            return DotaForDrawing(list);
        }
    }
}
