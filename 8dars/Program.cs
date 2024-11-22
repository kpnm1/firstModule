using _8dars.Models;
using _8dars.Services;

namespace _8dars;

internal class Program
{
    static void Main(string[] args)
    {


    }

    public static void StartProgram()
    {
        var bookService = new BookService();

        while (true)
        {
            Console.WriteLine("1. Add book");
            Console.WriteLine("2. Remove book");
            Console.WriteLine("3. Bring all books");
            Console.WriteLine("4. Bring book");
            Console.WriteLine("5. Edit book");
            Console.Write("Choose option: ");
            var option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                var newBook = new Book();

                Console.Write("Who is the book author: ");
                newBook.Author = Console.ReadLine();

                Console.Write("Summary of the book: ");
                newBook.Summary = Console.ReadLine();

                Console.Write("What type of genre is the book: ");
                newBook.Genre = Console.ReadLine();

                Console.Write("Enter guid of the book: ");
                newBook.Id = Guid.Parse(Console.ReadLine());

                Console.Write("Enter title of the book: ");
                newBook.Title = Console.ReadLine();

                Console.Write("Enter publication year: ");
                newBook.PublicationYear = int.Parse(Console.ReadLine());

                Console.Write("How many pages: ");
                newBook.PageCount = int.Parse(Console.ReadLine());

                Console.Write("Enter edition: ");
                newBook.Edition = Console.ReadLine();

                Console.Write("Digital version does have: ");
                newBook.DigitalVersionAvailable = bool.Parse(Console.ReadLine());

                bookService.AddBook(newBook);
            }
        }
    }
}
