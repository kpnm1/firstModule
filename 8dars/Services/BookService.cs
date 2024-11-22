using _8dars.Models;

namespace _8dars.Services;

public class BookService
{
    private List<Book> books;
    public BookService()
    {
        books = new List<Book>();
        DataSeed();
    }

    public Book AddBook(Book book)
    {
        book.Id = Guid.NewGuid();
        books.Add(book);

        return book;
    }

    public bool RemoveBook(Guid bookId)
    {
        var exists = false;
        foreach (var book in books)
        {
            if (book.Id == bookId)
            {
                exists = true;
                books.Remove(book);
                break;
            }
        }

        return exists;
    }

    public bool UpgradeBook(Book editedBook)
    {
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].Id == editedBook.Id)
            {
                books[i] = editedBook;
                return true;
            }
        }

        return false;
    }

    public List<Book> BringBooks()
    {
        return books;
    }

    public Book GetBookById(Guid id)
    {
        foreach (var book in books)
        {
            if (book.Id == id)
            {
                return book;
            }
        }

        return null;
    }

    private void DataSeed()
    {
        var fictionBook = new Book()
        {
            Title = "To Kill a Mockingbird",
            Author = "Harper Lee",
            PublicationYear = 1960,
            Genre = "Fiction",
            PageCount = 281,
            Edition = "50th Anniversary Edition",
            Price = 9.99,
            Summary = "A gripping, heart-wrenching novel about racial injustice in the Depression-era South."
        };

        var sciFiBook = new Book()
        {
            Title = "Dune",
            Author = "Frank Herbert",
            PublicationYear = 1965,
            Genre = "Science Fiction",
            PageCount = 412,
            Edition = "Deluxe Edition",
            Price = 18.99,
            Summary = "A science fiction epic about politics, religion, and ecology " +
            "on the desert planet Arrakis."
        };

        var nonFictionBook = new Book()
        {
            Title = "Educated",
            Author = "Tara Westover",
            PublicationYear = 2018,
            Genre = "Memoir",
            PageCount = 334,
            Edition = "First Edition",
            Price = 14.99,
            Summary = "A memoir about a woman who grows up in a survivalist " +
            "family in rural Idaho and goes on to earn a PhD from Cambridge."
        };

        books.Add(fictionBook);
        books.Add(sciFiBook);
        books.Add(nonFictionBook);
    }

}
