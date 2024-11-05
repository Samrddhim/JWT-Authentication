using CRUDapplicationUsingLayers2.Model;
using CRUDapplicationUsingLayers2.Model.Entities;
using CRUDapplicationUsingLayers2.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDapplicationUsingLayers2.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookDto book)
        {
            await bookService.AddBook(book);
            return Ok(book);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateBook(UpdateBookDto book,Guid id)
        {
            await bookService.UpdateBook(book, id);
            return Ok(book);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await bookService.GetAllBooks());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            return Ok(await bookService.GetBookById(id));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteBookById(Guid id)
        {
            await bookService.DeleteBookById(id);
            return Ok();
        }
    }
}
