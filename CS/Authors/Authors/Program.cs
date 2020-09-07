using System;
using System.Linq;

namespace Authors
{
    class Program
    {
        class Author
        {
            public string firstName { get; set; }
            public string lastName { get; set; }

            public override string ToString()
            {
                return $"\nAuthor: {this.firstName} {this.lastName}";
            }
        }

        static void Main(string[] args)
        {
            Author[] authors =
            {
                new Author{firstName = "Aleksei1", lastName ="Krosmki1" },
                new Author{firstName = "Aleksei2", lastName ="Krosmki2"},
                new Author{firstName = "Aleksei3", lastName ="Krosmki3"},
            };

            /*
            for(int i = 0; i < authors.Length; i++)
            {
                Console.WriteLine(authors[i]);
            }
            */

            foreach (Author a in authors)
            {
                Console.WriteLine(a);
            
            }

            //-------------LIKQ---------------
            Console.WriteLine("===LINQ===");
            var selectedAuthors = from author in authors
                                  where author.firstName == "Aleksei1"
                                  select author;
            foreach(Author a in selectedAuthors)
            {
                Console.WriteLine(a);
            }

            Console.ReadKey();
        }
    }
}
