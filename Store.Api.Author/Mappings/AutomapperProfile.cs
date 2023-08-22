using AutoMapper;
using Store.Api.Author.DTOs;
using Store.Api.Author.Model;

namespace Store.Api.Author.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<BookAuthor, AuthorDto>();
        }
    }
}
