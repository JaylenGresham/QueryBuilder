using QueryBuilder;

namespace QueryBuilder
{
    public class Program
    {
        static void Main(string[] args)
        {
            var database = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString() + "\\Data\\data.db";

            List<Author> authors;
            using (var qb = new QueryBuilder(database))
            {
                var sk = new Author(4, "Jack", "Boomhower");
                qb.Create<Author>(sk);

                authors = qb.ReadAll<Author>();
                var readOne = qb.Read<Author>(4);

                sk.Id = 4;
                sk.FirstName = "Boomhower";
                sk.Surname = "Jack";
                qb.Update(sk);
                
                qb.Delete<Author>(sk);
            }

            foreach (var author in authors)
            {
                Console.WriteLine(author);
            }

        }
    }
}









