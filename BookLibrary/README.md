# BookLibrary Console Application

A simple C# console application for managing a personal book library. This project demonstrates object-oriented programming concepts including classes, inheritance, polymorphism, and encapsulation.

## Features

- Add books to your library
- Search for books by ISBN
- Delete books from your library
- Filter books by genre
- Export filtered book lists to text files
- File-based storage system

## Prerequisites

- .NET 9.0 or later
- Windows, macOS, or Linux

## How to Run

### Option 1: Using Visual Studio Code or Visual Studio

1. Open the project folder in your IDE
2. Build and run the project (F5 or Ctrl+F5)

### Option 2: Using Command Line

1. Navigate to the project directory:

   ```bash
   cd BookLibrary
   ```

2. Build the project:

   ```bash
   dotnet build
   ```

3. Run the application:

   ```bash
   dotnet run
   ```

## How to Use

When you start the program, you'll see a menu with the following options:

```text
---------------------------
Welcome to Ela's Library~
0 - quit program
1 - add a book
2 - retrieve a book
3 - delete a book
4 - get books by genre
```

## Input Requirements

### ISBN Format

- Must be exactly 10 characters long
- Must contain only numeric digits (0-9)

### Date Format

- Year: Must be between 1000 and 2024
- Month: Must be between 1 and 12
- Day: Must be between 1 and 31

## Sample Books

The program comes with two pre-loaded books:

- "Serpent and the Wings of Night" by Carissa Broadbent (Fantasy)
- "The Songbird and a Heart of Stone" by Carissa Broadbent (Fantasy)

## Project Structure

- **Book Class**: Represents a book with author, title, publish date, ISBN, and genre
- **Library Class**: Manages the collection of books with static methods
- **Genre Enum**: Defines available book genres
- **Writer Class**: Handles file output operations
- **ConsoleHelper Class**: Provides utility methods for console interaction
- **IBookValidator Interface**: Validates ISBN format

## Technical Notes

- Books are stored in memory using a Dictionary with ISBN as the key
- The application uses basic error handling for invalid inputs
- Date validation has simplified bounds checking
- Generated text files are saved in the same directory as the executable

## Known Limitations

- Books are not persisted between application runs
- Date validation doesn't account for leap years or month-specific day limits
- No duplicate book detection beyond ISBN
- Simple error handling without comprehensive edge case coverage

## Example Usage Session

```text
Welcome to Ela's Library~
0 - quit program
1 - add a book
2 - retrieve a book
3 - delete a book
4 - get books by genre
: 1

Specify the book in this format (author-book title-publishedYear-publishedMonth-publishedDate-ISBN):
J.K. Rowling-Harry Potter and the Sorcerer's Stone-1997-6-26-1234567890

Choose the genre:
0 - Romance
1 - Fantasy
2 - SciFi
3 - Mystery
4 - Thriller
5 - Horror
6 - Historical
: 1

Harry Potter and the Sorcerer's Stone by J.K. Rowling was published on 6/26/1997. (ISBN: 1234567890) - (Genre: Fantasy)
```

---

*This is a learning project focused on demonstrating C# programming concepts. Some edge cases and production-level features are intentionally simplified.*
