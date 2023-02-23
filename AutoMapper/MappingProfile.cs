using AutoMapper;
using BookApi.Dtos;
using BookApi.Models;

namespace BookApi.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<GetBookDto, Book>();
            CreateMap<PostBookDto, Book>();
        }
    }
}
