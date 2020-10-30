using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookStore
{
    public class ComicBookStore
    {
        public List<ComicBook> ComicBooks { get; set; }

        public ComicBookStore(string fileName)
        {
            ComicBooks = new List<ComicBook>();
            ReadComicBookList(fileName);
        }
        public void SearchByTitle(string Title)
        {
            for (int index = 0; index < ComicBooks.Count; index++)
            {
                ComicBooks[index].IsMatched = ComicBooks[index].TitleName.ToUpper().Contains(Title.ToUpper());
            }
        }
        public void SearchByPublisher(string Publisher)
        {
            for (int index = 0; index < ComicBooks.Count; index++)
            {
                ComicBooks[index].IsMatched = ComicBooks[index].PublisherName.ToUpper().Contains(Publisher.ToUpper());
            }
        }
        public void SearchByPrice(string Price)
        {
            for (int index = 0; index < ComicBooks.Count; index++)
            {
                ComicBooks[index].IsMatched = false;
                double titlePrice;
                if (double.TryParse(Price.Replace("$", ""), out titlePrice))
                {
                    ComicBooks[index].IsMatched = (ComicBooks[index].TitlePrice == titlePrice);
                }                        
            }
        }

        private string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }
        private void ReadComicBookList(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    ComicBook comicBook = new ComicBook();
                    string[] values = line.Split(',');
                    DateTime comicDate;
                    if (DateTime.TryParse(values[0], out comicDate))
                    {
                        comicBook.ComicDate = comicDate;
                    }
                    comicBook.PublisherName = values[1];
                    comicBook.TitleName = values[2];
                    double titlePrice;
                    if (double.TryParse(values[3].Replace("$", ""), out titlePrice))
                    {
                        comicBook.TitlePrice = titlePrice;
                    }
                    ComicBooks.Add(comicBook);
                }
            }
        }
    }
}
