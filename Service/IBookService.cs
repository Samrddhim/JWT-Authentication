using CRUDapplicationUsingLayers2.Model.Entities;
using CRUDapplicationUsingLayers2.Model;

namespace CRUDapplicationUsingLayers2.Service
{
    public interface IBookService
    {
        public Task<Book> AddBook(AddBookDto addBookDto);
        public Task<Book?> UpdateBook(UpdateBookDto updateBookDto, Guid id);

        public Task<IEnumerable<Book>> GetAllBooks();
        public Task<Book?> GetBookById(Guid id);

        public Task DeleteBookById(Guid id);
    }
}
