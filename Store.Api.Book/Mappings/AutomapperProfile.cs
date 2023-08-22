using AutoMapper;
using Store.Api.Book.DTOs;
using Store.Api.Book.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Book.Mappings
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<BookModel, BookDto>();
        }
    }
}
