using AutoMapper;
using Bookstore.Application.DTOs;
using Bookstore.Domain.Entities;

namespace Bookstore.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Book, BookDTO>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
    }
}
