using AutoMapper;
using DomainModel.Dtos;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();

            CreateMap<Genre, GenreDto>().ReverseMap();

        }
    }
}
