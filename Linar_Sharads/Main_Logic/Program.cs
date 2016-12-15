

using System;

namespace Main_Logic
{
    internal class Program
    {
        private static void Main()
        {
            //Test
            //using (var context = new Context())
            //{
            //    context.Database.Delete();
            //    context.Database.CreateIfNotExists();

            //    context.SaveChanges();
            //}
            //var kek = GetUserGraphUnfoInfo.KoefArray("../../../Main_Logic/image.jpeg");
            //System.Console.ReadLine();
            Repository repository = new Repository();

            int i = 0;
            foreach (var item in repository.GetKoefs())
            {
                Console.WriteLine(i++);
            }
            Console.ReadKey();




            //repo.GetKoefs();
        }
    }
}
