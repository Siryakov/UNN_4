// See https://aka.ms/new-console-template for more information
using _5_2_BookTriangle.Book;
using _5_2_BookTriangle.Figure;

Book book = new Book("Harry Potter", "JK Rowling", 1000);
BookGanre bookGanre = new BookGanre(book, "Fantasy");
BookGenrePubl_ bookGenrePubl = new BookGenrePubl_("Mr X", "MS Y", 777, "Detective", "Kometa LLC");

Console.WriteLine("Book:");
book.Print();

Console.WriteLine("\nBookGanre:");
bookGanre.Print();

Console.WriteLine("\nBookGenrePubl_:");
bookGenrePubl.Print();



Console.WriteLine("\n \n \n \n");



Figure triangle = new Triangle("Triangle", 3, 4, 5);
Figure triangleColor = new TriangleColor("Colored Triangle", 6, 8, 10, "Red");


Console.WriteLine("Information about the figures:");
triangle.Print();
triangleColor.Print();
Console.WriteLine();


Console.WriteLine($"Area of {triangle.Name}: {triangle.Area()}");
Console.WriteLine($"Area of {triangleColor.Name}: {triangleColor.Area()}");
Console.WriteLine();


Console.WriteLine($"Area2 of {triangle.Name}: {triangle.Area2}");
Console.WriteLine($"Area2 of {triangleColor.Name}: {triangleColor.Area2}");
    


