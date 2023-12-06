using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_2_BookTriangle.Book
{
    sealed class BookGenrePubl_ : BookGanre
    {
        string Publisher { get; set; }

        public BookGenrePubl_(string title, string author, double price, string genre, string publisher) : base(title, author, price, genre)
        {
            this.Publisher = publisher;
        }
        //public BookGenrePubl_(BookGanre bookGanre, string publisher) : base(bookGanre, bookGanre.Genre)
        //{
        //    Publisher = publisher;
        //}
        public new void Print()
        {
            base.Print();
            Console.WriteLine($"Publisher: {Publisher}");
        }
    }
}
