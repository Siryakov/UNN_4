using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_2_BookTriangle.Book
{
    internal class BookGanre : Book, IEquatable<BookGanre?>
    {
        String Genre { get; set; }
        public BookGanre(string title, string author, double price, string genre) : base(title, author, price)
        {
            Genre = genre;
        }
        public BookGanre(Book book, string genre) : base(book.Title, book.Author, book.Price)
        {
            Genre = genre;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as BookGanre);
        }

        public bool Equals(BookGanre? other)
        {
            return other is not null &&
                   Title == other.Title &&
                   Author == other.Author &&
                   Price == other.Price &&
                   Genre == other.Genre;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Author, Price, Genre);
        }

        public static bool operator ==(BookGanre? left, BookGanre? right)
        {
            return EqualityComparer<BookGanre>.Default.Equals(left, right);
        }

        public static bool operator !=(BookGanre? left, BookGanre? right)
        {
            return !(left == right);
        }

        public new void Print()
        {
            base.Print();
            Console.WriteLine($"Genre: {Genre}");
        }
    }
}
