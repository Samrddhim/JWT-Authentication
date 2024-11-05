using CRUDapplicationUsingLayers2.Model.Entities;
using CRUDapplicationUsingLayers2.Model;
using CRUDapplicationUsingLayers2.Repository;
using CRUDapplicationUsingLayers2.Service;

public class BookService : IBookService
{
    private readonly IBookRepository bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        this.bookRepository = bookRepository;
    }

    public async Task<Book> AddBook(AddBookDto addBookDto)
    {
        
        // Ensure NoOfCopy is a valid positive number
        if (addBookDto.NoOfCopy <= 0)
        {
            throw new ArgumentException("Number of copies must be greater than zero.");
        }

        return await bookRepository.AddBook(addBookDto);
    }

    public async Task<Book?> UpdateBook(UpdateBookDto updateBookDto, Guid id)
    {
        // Business Logic: Ensure NoOfCopy is not zero or negative
        if (updateBookDto.NoOfCopy <= 0)
        {
            throw new ArgumentException("Number of copies must be greater than zero.");
        }

        // Check if the book exists before updating
        var bookToUpdate = await bookRepository.GetBookById(id);
        if (bookToUpdate == null)
        {
            return null;  // we can also throw custom exceptions
        }

        // Other business logic: Prevent updates on certain categories, e.g., restricted books
        if (bookToUpdate.Category == "Restricted")
        {
            throw new InvalidOperationException("Updates are not allowed on restricted category books.");
        }

        return await bookRepository.UpdateBook(updateBookDto, id);
    }

    public async Task DeleteBookById(Guid id)
    {
        // Business Logic: Prevent deletion if the book has a limited number of copies
        var book = await bookRepository.GetBookById(id);
        if (book == null)
        {
            throw new KeyNotFoundException("The book to delete was not found.");
        }

        if (book.NoOfCopy < 5)
        {
            throw new InvalidOperationException("Cannot delete a book with fewer than 5 copies.");
        }

        await bookRepository.DeleteBookById(id);
    }

    public async Task<IEnumerable<Book>> GetAllBooks()
    {
        // Business Logic: Filter books based on some condition, like excluding "Archived" books
        var books = await bookRepository.GetAllBooks();
        return books.Where(b => b.Category != "Archived");
    }

    public async Task<Book?> GetBookById(Guid id)
    {
        // Business Logic: Could add logging or auditing here
        return await bookRepository.GetBookById(id);
    }
}
