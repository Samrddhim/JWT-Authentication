using CRUDapplicationUsingLayers2.Data;
using CRUDapplicationUsingLayers2.Model;
using CRUDapplicationUsingLayers2.Model.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CRUDapplicationUsingLayers2.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public BookRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<Book> AddBook(AddBookDto addBookDto)
        {
            var bookEntity = new Book()
            {
                BookName = addBookDto.BookName,
                Category = addBookDto.Category,
                NoOfCopy = addBookDto.NoOfCopy,
                AuthorName = addBookDto.AuthorName

            };

            await applicationDbContext.Books.AddAsync(bookEntity);
            await applicationDbContext.SaveChangesAsync();
            return bookEntity;

        }

        public async Task DeleteBookById(Guid id)
        {
            var book = await applicationDbContext.Books.FindAsync(id);
            if (book != null)
            {
                applicationDbContext.Remove(book);
                await applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
           return await applicationDbContext.Books.ToListAsync();
        }

        public async Task<Book?> GetBookById(Guid id)
        {
            return await applicationDbContext.Books.FindAsync(id);
           
        }

        public async Task<Book?> UpdateBook(UpdateBookDto updateBookDto, Guid id)
        {
            var book = await applicationDbContext.Books.FindAsync(id);
            if (book == null)
            {
                return null;
                
            }
            book.BookName = updateBookDto.BookName;
            book.AuthorName = updateBookDto.AuthorName;
            book.Category = updateBookDto.Category;
            book.NoOfCopy = updateBookDto.NoOfCopy;

            applicationDbContext.Books.Update(book);
            await applicationDbContext.SaveChangesAsync();
            return book;

        }
    }
}
