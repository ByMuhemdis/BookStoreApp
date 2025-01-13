using AutoMapper;
using Entities.Models;
using Store.Application.DTOs.AuthorDtos;
using Store.Application.DTOs.BookDtos;
using Store.Application.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author,AuthorDto>().ReverseMap();

            CreateMap<Book,BookDto>().ReverseMap();
            CreateMap<Book, BookUpdateDto>().ReverseMap();

            CreateMap<Category,CategoryDto>().ReverseMap();
        }
    }
}
