using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Example.Core.DTOs;
using Example.Core.Models;


namespace Example.Core.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.TitleDto, opt => opt.MapFrom(src => src.Title));
            CreateMap<BookDto, Book>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.TitleDto));
        }
    }
}
