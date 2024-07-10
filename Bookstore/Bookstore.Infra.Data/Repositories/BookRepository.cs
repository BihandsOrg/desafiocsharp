using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using Bookstore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infra.Data.Repositories;

public class BookRepository : IBookRepository
{
    private ApplicationDbContext _bookContext;
    public BookRepository(ApplicationDbContext context)
    {
        _bookContext = context;
    }

    public async Task<Book> CreateAsync(Book product)
    {
        _bookContext.Add(product);
        await _bookContext.SaveChangesAsync();
        return product;
    }

    public async Task<Book> GetByIdAsync(int? id)
    {
        return await _bookContext.Books.FindAsync(id);
    }

    public async Task<Book> GetBookCategoryAsync(int? id)
    {
        //eager loading
        return await _bookContext.Books.Include(c => c.Category)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Book>> GetBooksOrderByAscendingAsync()
    {
        return await _bookContext.Books.ToListAsync();
    }

    public async Task<Book> RemoveAsync(Book product)
    {
        _bookContext.Remove(product);
        await _bookContext.SaveChangesAsync();
        return product;
    }

    public async Task<Book> UpdateAsync(Book product)
    {
        _bookContext.Update(product);
        await _bookContext.SaveChangesAsync();
        return product;
    }
}
