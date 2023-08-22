using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.Api.Book.DTOs;
using Store.Api.Book.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Api.Book.Application
{
    public class SelectBookCommand
    {
        public class Execute: IRequest<List<BookDto>> { }

        public class Handler : IRequestHandler<Execute, List<BookDto>>
        {
            private readonly BookContext _context;
            private readonly IMapper _mapper;

            public Handler(BookContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<BookDto>> Handle(Execute request, CancellationToken cancellationToken)
            {
                var books = await  _context.Book.ToListAsync();
                var booksDto = _mapper.Map<List<BookDto>>(books);

                return booksDto;
            }
        }
    }
}
