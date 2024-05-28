using AutoMapper;
using BookManagement.Application.Dtos;
using BookManagement.Application.DTOs;
using BookManagement.Entities.Models;

namespace BookManagement.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, CreateEditAuthorDto>().ReverseMap();
        }
    }
}
