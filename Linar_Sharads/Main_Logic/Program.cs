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
            var repo = new Repository();
            //repo.GetKoefs();
        }
    }
}
