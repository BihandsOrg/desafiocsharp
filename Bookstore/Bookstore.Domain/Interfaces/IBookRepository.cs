using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetBooksOrderByAscendingAsync();
    Task<Book> GetByIdAsync(int? id);

    Task<Book> GetBookCategoryAsync(int? id);

    Task<Book> CreateAsync(Book book);
    Task<Book> UpdateAsync(Book book);
    Task<Book> RemoveAsync(Book book);
}
