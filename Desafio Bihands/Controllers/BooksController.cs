using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Desafio_Bihands.Data;

namespace Desafio_Bihands.Controllers
{
    /// <summary>
    /// Controlador para gerenciar os livros da biblioteca.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        /// <summary>
        /// Inicializa uma nova instância do <see cref="BooksController"/>.
        /// </summary>
        /// <param name="context">O contexto do banco de dados.</param>
        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém uma lista paginada de livros.
        /// </summary>
        /// <param name="page">O número da página.</param>
        /// <param name="pageSize">O tamanho da página.</param>
        /// <returns>Uma lista de livros.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            return await _context.Books
                .OrderBy(b => b.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        /// <summary>
        /// Obtém um livro pelo seu identificador.
        /// </summary>
        /// <param name="id">O identificador do livro.</param>
        /// <returns>O livro correspondente ao identificador.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        /// <summary>
        /// Adiciona um novo livro.
        /// </summary>
        /// <param name="book">O livro a ser adicionado.</param>
        /// <returns>O livro adicionado.</returns>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            if (_context.Books.Any(b => b.Name == book.Name))
            {
                return Conflict("Book already exists.");
            }
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        /// <summary>
        /// Atualiza um livro existente.
        /// </summary>
        /// <param name="id">O identificador do livro a ser atualizado.</param>
        /// <param name="book">O livro atualizado.</param>
        /// <returns>Nenhum conteúdo.</returns>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            _context.Entry(book).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Books.Any(b => b.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        /// <summary>
        /// Remove um livro existente.
        /// </summary>
        /// <param name="id">O identificador do livro a ser removido.</param>
        /// <returns>Nenhum conteúdo.</returns>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
