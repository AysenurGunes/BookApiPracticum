using AutoMapper;
using BookApi.Dtos;
using BookApi.Models;

namespace BookApi.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<PutBookDto, Book>();
            CreateMap<PostBookDto, Book>();
            CreateMap<PutBookTypeDto, BookType>();
            CreateMap<PostBookTypeDto, BookType>(); 
            CreateMap<PutPublisherDto, Publisher>();
            CreateMap<PostPublisherDto, Publisher>();
        }
    }
}
