using Bookstore.Application.DTOs;

namespace Bookstore.Application.Interfaces;

public interface IBookService
{
    Task<IEnumerable<BookDTO>> GetBooksOrderByAscending();
    Task<BookDTO> GetById(int? id);

    Task<BookDTO> GetBookCategory(int? id);
    Task Add(BookDTO bookDto);
    Task Update(BookDTO bookDto);
    Task Remove(int? id);
}
