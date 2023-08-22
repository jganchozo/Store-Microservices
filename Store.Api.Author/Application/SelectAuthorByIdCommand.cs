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
    public class SelectAuthorByIdCommand
    {
        public class GetAuthor : IRequest<AuthorDto>
        {
            public string AuthorGuid { get; set; }
        }

        public class Handler : IRequestHandler<GetAuthor, AuthorDto>
        {
            private readonly AuthorContext _context;
            private readonly IMapper _mapper;

            public Handler(AuthorContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AuthorDto> Handle(GetAuthor request, CancellationToken cancellationToken)
            {
                var author = await _context.Author.FirstOrDefaultAsync(x => x.AuthorGuid == request.AuthorGuid);

                if (author is null)
                {
                    throw new Exception("Author does not exist");
                }

                var authorDto = _mapper.Map<AuthorDto>(author);

                return authorDto;
            }
        }
    }
}
