using Bookstore.Application.DTOs;
using Bookstore.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> Get()
        {
            var books = await _bookService.GetBooksOrderByAscending();
            var booksOrderByAscending = books.OrderBy(b => b.Title);
            if (booksOrderByAscending == null)
            {
                return NotFound("Books not found");
            }
            return Ok(booksOrderByAscending);
        }

        [AllowAnonymous]
        [HttpGet("{id:int}", Name = "GetBook")]
        public async Task<ActionResult<BookDTO>> Get(int id)
        {
            var book = await _bookService.GetById(id);
            if (book == null)
            {
                return NotFound("Book not found");
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BookDTO bookDto)
        {
            var books = await _bookService.GetBooksOrderByAscending();

            if (bookDto == null)
                return BadRequest("Invalid Data");

            if(books.Where(b => b.Title == bookDto.Title).FirstOrDefault() != null)
                return BadRequest("Book already exists");
            
            await _bookService.Add(bookDto);

            return new CreatedAtRouteResult("GetBook", new { id = bookDto.Id },
                bookDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] BookDTO bookDto)
        {
            if (id != bookDto.Id)
                return BadRequest("Data Invalid");

            if (bookDto == null)
                return BadRequest("Data Invalid");

            await _bookService.Update(bookDto);

            return Ok(bookDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<BookDTO>> Delete(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
            {
                return NotFound("Book not found");
            }

            await _bookService.Remove(id);

            return Ok(book);
        }
    }
}
