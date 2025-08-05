// BookLibrary - a console program :)

// Users can add, get, and remove books from a file-based collection.
// Option to save and load books from a .txt or .json file
// Simple menu system for user interaction
// Implement class relationships, learn input/output to file.

// Entities:
// Book class - stores information about a book (author, title, year, ISBN, genre (enum))
// Library class - stores a collection of Books and has static methods
// Genre - an enum
// File Manager? class - abstract. handles file input/output

Book myBook = Library.AddBook("Carissa Broadbent", "Serpent and the Wings of Night", new DateTime(2020, 11, 26), "0123456789", Genre.Fantasy);
Console.WriteLine(myBook.ToString());

try
{
    Book foundBook;
    if (Library.GetBook("01234567", out foundBook))
    {
        Console.WriteLine(foundBook.ToString());
    }
}
catch (ArgumentException e)
{
    Console.WriteLine($"Error: {e.Message}");
}




class BookValidator
{
    protected static bool IsValidIsbn(string isbn)
    { 
        foreach (char s in isbn)
        {
            if (!char.IsDigit(s))
            {
                return false;
            }
        }
        return isbn.Length == 10;
    }
}

enum Genre
{
    Romance, 
    Fantasy, 
    SciFi, 
    Mystery, 
    Thriller, 
    Horror,
    Adventure,
    Historical, 
    NonFiction,
    YoungAdult
}

class Book : BookValidator
{
    string Author { get; }
    string Title { get; }
    DateTime PublishDate { get; }
    string Isbn { get; }
    Genre Genre { get; }

    public Book(string author, string title, DateTime publishDate, string isbn, Genre genre)
    {
        if (!IsValidIsbn(isbn))
        {
            throw new ArgumentException("The ISBN must be a 10-character and contain only numeric characters (0 to 9).");
        }

        Author = author;
        Title = title;
        PublishDate = publishDate;
        Isbn = isbn;
        Genre = genre;
    }

    public override string ToString()
    {
        return $"{Title} by {Author} was published on {PublishDate.ToString("d")}. (ISBN: {Isbn}) - (Genre: {Genre})";
    }
}

class Library : BookValidator
{
    static Dictionary<string, Book> libraryDict = new Dictionary<string, Book>();

    public static Book AddBook(string author, string title, DateTime publishDate, string isbn, Genre genre)
    {
        Book newBook = new Book(author, title, publishDate, isbn, genre);
        libraryDict.Add(isbn, newBook);
        return newBook;
    }

    public static bool GetBook(string isbn, out Book book)
    {
        if (!IsValidIsbn(isbn))
        {
            throw new ArgumentException("Invalid ISBN format.");
        }
        return libraryDict.TryGetValue(isbn, out book);
    }

    public static string DeleteBook(string isbn)
    {
        if (!IsValidIsbn(isbn))
        {
            throw new ArgumentException("Invalid ISBN format.");
        }
        if (libraryDict.ContainsKey(isbn))
        {
            libraryDict.Remove(isbn);
            return "Success";
        } else
        {
            return "This book does not exist in the library";
        }
    }

    public static List<Book> GetBooksByGenre(Genre genre)
    {
        return libraryDict.Values
            .Where(book => book.Genre == genre)
            .toList();
    }
}