// BookLibrary - a console program :)
// Made for the purpose of implementing what I've learned so far about classes, inheritance, polymorphism, and encapsulation (among other things in C#) without making too complex of an application.
// Due to this, this program likely has some bugs, nuances, and edge cases that aren't addressed.

// Users can add, get, and remove books from a file-based collection.
// Save list of books into a .txt file
// Simple menu system for user interaction
// Implement class relationships, learn input/output to file.

// Entities:
// Book class - stores information about a book (author, title, year, ISBN, genre (enum))
// Library class - stores a collection of Books and has static methods
// Genre - an enum of genre types
// File Manager class - abstract. handles file input/output

Book myBook = Library.AddBook("Carissa Broadbent", "Serpent and the Wings of Night", new DateTime(2020, 11, 26), "0123456789", Genre.Fantasy);
Book myBook2 = Library.AddBook("Carissa Broadbent", "The Songbird and a Heart of Stone", new DateTime(2024, 1, 23), "9876543210", Genre.Fantasy);

string input = "";
while (input != "0")
{
    Console.WriteLine("\n---------------------------");
    Console.WriteLine("Welcome to Ela's Library~");
    Console.WriteLine("0 - quit program\n1 - add a book\n2 - retrieve a book\n3 - delete a book\n4 - get books by genre");
    Console.Write(": ");
    input = (Console.ReadLine() ?? "").Trim();

    switch (input)
    {
        case "0":
            return;
        case "1":
            Console.WriteLine("Specify the book in this format (author-book title-publishedYear-publishedMonth-publishedDate-ISBN): ");
            string bookInput = (Console.ReadLine() ?? "").Trim();
            if (bookInput.Length > 0)
            {
                string[] bookInputArray = bookInput.Split("-");
                if (bookInputArray.Length == 6)
                {
                    // hardcoded bounds are for simplicity. there are edge cases for sure.
                    // check if the entered string representation of INT values are valid in their context (year/month/day).
                    bool isYear = int.TryParse(bookInputArray[2], out int yearResult) & yearResult > 1000 & yearResult < 2025;
                    bool isMonth = int.TryParse(bookInputArray[3], out int monthResult) & monthResult >= 1 & monthResult <= 12;
                    bool isDay = int.TryParse(bookInputArray[4], out int dayResult) & dayResult >= 1 & dayResult <= 31;
                    if (isYear && isMonth && isDay)
                    {
                        ConsoleHelper.OutputGenreChoices();
                        string genreAddInput = (Console.ReadLine() ?? "").Trim();
                        bool isInt = int.TryParse(genreAddInput, out int genreNumber);

                        if (isInt && genreNumber <= 6 && genreNumber >= 0)
                        {
                            try
                            {
                                Book newBook = Library.AddBook(
                                    bookInputArray[0],
                                    bookInputArray[1],
                                    new DateTime(yearResult, monthResult, dayResult),
                                    bookInputArray[5],
                                    (Genre)genreNumber
                                );
                                Console.WriteLine(newBook.ToString());
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine($"{e.Message}. Please try again.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: The genre you selected is not valid. Please try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: The entered published year/month/day is invalid. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: There is missing book information. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Error: Invalid input. Please try again.");
            }
            break;
        case "2":
            Console.WriteLine("Enter ISBN code of the book: ");
            Console.Write(": ");
            string isbnInput = (Console.ReadLine() ?? "").Trim();
            try
            {
                bool bookFound = Library.GetBook(isbnInput, out Book book);
                if (bookFound)
                {
                    Console.WriteLine("\n" + book.ToString());
                }
                else
                {
                    Console.WriteLine($"Book with ISBN {isbnInput} does not exist in this library.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message} Please try again.");
            }
            
            break;
        case "3":
            Console.WriteLine("Enter the ISBN of the book to delete:");
            Console.Write(": ");
            string isbnDeleteInput = (Console.ReadLine() ?? "").Trim();

            try
            {
                bool bookFound = Library.DeleteBook(isbnDeleteInput);
                if (bookFound)
                {
                    Console.WriteLine("\n" + "Successfully deleted book.");
                }
                else
                {
                    Console.WriteLine($"Book with ISBN {isbnDeleteInput} does not exist in this library.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message} Please try again.");
            }

            break;
        case "4":
            ConsoleHelper.OutputGenreChoices();
            string genreGetBooksInput = (Console.ReadLine() ?? "").Trim();
            bool isIntInput = int.TryParse(genreGetBooksInput, out int genreGetBooksNumber);

            if (isIntInput && genreGetBooksNumber <= 6 && genreGetBooksNumber >= 0)
            {
                List<Book> bookList = Library.GetBooksByGenre((Genre)genreGetBooksNumber);
                bool fileSaved = Writer.SaveToTxtFile(bookList, out string fileName);
                if (fileSaved)
                {
                    Console.WriteLine($"Books saved to {fileName}.");
                }
                else
                {
                    Console.WriteLine("There was an error creating and/or saving the file");
                }
            }
            
            break;

    }
}

class ConsoleHelper
{
    public static void OutputGenreChoices()
    {
        Console.WriteLine("Choose the genre: ");
        Console.WriteLine("0 - Romance");
        Console.WriteLine("1 - Fantasy");
        Console.WriteLine("2 - SciFi");
        Console.WriteLine("3 - Mystery");
        Console.WriteLine("4 - Thriller");
        Console.WriteLine("5 - Horror");
        Console.WriteLine("6 - Historical");
        Console.Write(": ");
    }
}

class Writer
{
    // accepts content that will be saved to .txt file
    public static bool SaveToTxtFile(List<Book> bookList, out string fileName)
    {
        DateTimeOffset timestamp = DateTimeOffset.Now;
        fileName = $"{timestamp.ToString("MMddyyyy_hhmmss")}_output.txt";
        foreach (Book book in bookList)
        {
            File.AppendAllText(fileName, $"{book.ToString()}\n");
        }
        return File.Exists(fileName);
    }
}

interface IBookValidator
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
    Historical
}

class Book : IBookValidator
{
    string Author { get; }
    string Title { get; }
    DateTime PublishDate { get; }
    string Isbn { get; }
    public Genre PrimaryGenre { get; }

    public Book(string author, string title, DateTime publishDate, string isbn, Genre genre)
    {
        if (!IBookValidator.IsValidIsbn(isbn))
        {
            throw new ArgumentException("The ISBN must be a 10-character and contain only numeric characters (0 to 9).");
        }

        Author = author;
        Title = title;
        PublishDate = publishDate;
        Isbn = isbn;
        PrimaryGenre = genre;
    }

    public override string ToString()
    {
        return $"{Title} by {Author} was published on {PublishDate.ToString("d")}. (ISBN: {Isbn}) - (Genre: {PrimaryGenre})";
    }
}

class Library : IBookValidator
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
        if (!IBookValidator.IsValidIsbn(isbn))
        {
            throw new ArgumentException("Invalid ISBN format.");
        }
        return libraryDict.TryGetValue(isbn, out book);
    }

    public static bool DeleteBook(string isbn)
    {
        if (!IBookValidator.IsValidIsbn(isbn))
        {
            throw new ArgumentException("Invalid ISBN format.");
        }
        if (libraryDict.ContainsKey(isbn))
        {
            libraryDict.Remove(isbn);
            return true;
        } else
        {
            return false;
        }
    }

    public static List<Book> GetBooksByGenre(Genre genre)
    {
        return libraryDict.Values
            .Where(book => book.PrimaryGenre == genre)
            .ToList();
    }
}