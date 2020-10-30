using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookStore
{
    public class ComicBook
    {
        public DateTime ComicDate { get; set; }
        public string PublisherName { get; set; }
        public string TitleName { get; set; }
        public double TitlePrice { get; set; }
        public bool IsMatched { get; set; }

        public ComicBook()
        {
            TitlePrice = 0;
            IsMatched = false;
        }
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}",
                ComicDate.ToString("d"), PublisherName, TitleName, TitlePrice);
        }

}
}
