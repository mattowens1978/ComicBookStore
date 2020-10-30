using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ComicBookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            string fileName = Path.Combine(directory.FullName, "ComicBookList.txt");
            ComicBookStore comicBookStore = new ComicBookStore(fileName);
            //for (int index = 0; index < comicBookStore.ComicBooks.Count; index++)
            //{
            //    Console.WriteLine(comicBookStore.ComicBooks[index].ToString());
            //}

            string op;
            do
            {
                Console.WriteLine("Welcome to the Comic Book Store! What would you like to do?");
                Console.WriteLine("\t1 - Search by Title");
                Console.WriteLine("\t2 - Search by Publisher");
                Console.WriteLine("\t3 - Search by Price");
                Console.WriteLine("\t4 - Quit");
                Console.Write("Your option? ");

                op = Console.ReadLine();

                if (op == "1" || op == "2" || op == "3")
                {
                    Console.WriteLine("Enter search parameter, partials accepted:");
                    string search = Console.ReadLine();

                    if (op == "1")
                    {
                        comicBookStore.SearchByTitle(search);
                    }
                    else if (op == "2")
                    {
                        comicBookStore.SearchByPublisher(search);
                    }
                    else if (op == "3")
                    {
                        comicBookStore.SearchByPrice(search);
                    }
                    for (int index = 0; index < comicBookStore.ComicBooks.Count; index++)
                    {
                        if (comicBookStore.ComicBooks[index].IsMatched)
                        {
                            Console.WriteLine(comicBookStore.ComicBooks[index].ToString());
                        }
                    }
                }

                Console.WriteLine();
            }
            while (op != "4");
        }
    }
}
