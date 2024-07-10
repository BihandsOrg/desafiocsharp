using Bookstore.Application.DTOs;

namespace Bookstore.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategories();
    Task<CategoryDTO> GetById(int? id);
    Task Add(CategoryDTO categoryDto);
    Task Update(CategoryDTO categoryDto);
    Task Remove(int? id);
}
