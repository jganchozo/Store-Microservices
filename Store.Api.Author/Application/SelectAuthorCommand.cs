using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.Api.Author.DTOs;
using Store.Api.Author.Model;
using Store.Api.Author.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Api.Author.Application
{
    public class SelectAuthorCommand
    {
        public class GetAuthors : IRequest<List<AuthorDto>>
        {

        }

        public class Handler : IRequestHandler<GetAuthors, List<AuthorDto>>
        {
            private readonly AuthorContext _context;
            private readonly IMapper _mapper;

            public Handler(AuthorContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<AuthorDto>> Handle(GetAuthors request, CancellationToken cancellationToken)
            {
                var authors = await _context.Author.ToListAsync();
                var authorsDto = _mapper.Map<List<AuthorDto>>(authors);

                return authorsDto;
            }
        }
    }
}
