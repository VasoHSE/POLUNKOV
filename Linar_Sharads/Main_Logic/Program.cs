﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Logic
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new GetUserGraphUnfoInfo();
            var c = GetUserGraphUnfoInfo.FindXY(GetUserGraphUnfoInfo.ImageConvert("../../image.png"));
            Console.ReadLine();
        }
    }
}
