using AutoMapper;
using Store.Api.Book.DTOs;
using Store.Api.Book.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Api.Book.Tests
{
    class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<BookModel, BookDto>();
        }
    }
}
