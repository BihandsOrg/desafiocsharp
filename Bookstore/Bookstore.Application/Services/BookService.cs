using AutoMapper;
using Bookstore.Application.DTOs;
using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;

namespace Bookstore.Application.Services;

public class BookService : IBookService
{
    private IBookRepository _bookRepository;

    private readonly IMapper _mapper;
    public BookService(IMapper mapper, IBookRepository bookRepository)
    {
        _bookRepository = bookRepository ??
             throw new ArgumentNullException(nameof(bookRepository));

        _mapper = mapper;
    }

    public async Task<IEnumerable<BookDTO>> GetBooksOrderByAscending()
    {
        var booksEntity = await _bookRepository.GetBooksOrderByAscendingAsync();
        return _mapper.Map<IEnumerable<BookDTO>>(booksEntity);
    }

    public async Task<BookDTO> GetById(int? id)
    {
        var bookEntity = await _bookRepository.GetByIdAsync(id);
        return _mapper.Map<BookDTO>(bookEntity);
    }

    public async Task<BookDTO> GetBookCategory(int? id)
    {
        var bookEntity = await _bookRepository.GetBookCategoryAsync(id);
        return _mapper.Map<BookDTO>(bookEntity);
    }

    public async Task Add(BookDTO bookDto)
    {
        var bookEntity = _mapper.Map<Book>(bookDto);
        await _bookRepository.CreateAsync(bookEntity);
    }

    public async Task Update(BookDTO bookDto)
    {

        var bookEntity = _mapper.Map<Book>(bookDto);
        await _bookRepository.UpdateAsync(bookEntity);
    }

    public async Task Remove(int? id)
    {
        var bookEntity = _bookRepository.GetByIdAsync(id).Result;
        await _bookRepository.RemoveAsync(bookEntity);
    }
}
