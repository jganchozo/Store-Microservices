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
    public class SelectBookByIdCommand
    {
        public class Execute:IRequest<BookDto>
        {
            public Guid BookModelId { get; set; }
        }

        public class Handler : IRequestHandler<Execute, BookDto>
        {
            private readonly BookContext _context;
            private readonly IMapper _mapper;
            public Handler(BookContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async  Task<BookDto> Handle(Execute request, CancellationToken cancellationToken)
            {
                var book = await _context.Book.FirstOrDefaultAsync(x => x.BookModelId == request.BookModelId);

                if (book is null)
                {
                    throw new Exception("Book does not exist");
                }

                var bookDto = _mapper.Map<BookDto>(book);

                return bookDto;
            }
        }
    }
}
