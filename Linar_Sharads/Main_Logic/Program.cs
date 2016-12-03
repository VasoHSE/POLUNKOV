using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Main_Logic
{
    internal class Program
    {
        private static void Main()
        {
            //Test
            using (var context = new Context())
            {
                context.Database.Delete();
                context.Database.CreateIfNotExists();

                context.SaveChanges();
            }
        }
    }
}
