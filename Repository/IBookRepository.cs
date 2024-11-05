using CRUDapplicationUsingLayers2.Model;
using CRUDapplicationUsingLayers2.Model.Entities;

namespace CRUDapplicationUsingLayers2.Repository
{
    public interface IBookRepository
    {
        public Task<Book> AddBook(AddBookDto addBookDto);
        public Task<Book?> UpdateBook(UpdateBookDto updateBookDto, Guid id);

        public Task<IEnumerable<Book>> GetAllBooks();
        public Task<Book?> GetBookById(Guid id);

        public Task DeleteBookById(Guid id);

    }
}
