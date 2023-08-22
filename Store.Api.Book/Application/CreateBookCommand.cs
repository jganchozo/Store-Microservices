using FluentValidation;
using MediatR;
using Store.Api.Book.Model;
using Store.Api.Book.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Api.Book.Application
{
    public class CreateBookCommand
    {
        public class Execute : IRequest
        {
            public string Title { get; set; }
            public DateTime? PublicationDate { get; set; }
            public Guid? AuthorGuid { get; set; }
        }

        public class ExecuteValidations : AbstractValidator<Execute>
        {
            public ExecuteValidations()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.PublicationDate).NotEmpty();
                RuleFor(x => x.AuthorGuid).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly BookContext _context;

            public Handler(BookContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                BookModel book = new BookModel()
                {
                    Title = request.Title,
                    PublicationDate = request.PublicationDate,
                    AuthorGuid = request.AuthorGuid
                };

                await _context.Book.AddAsync(book);
                var result = await _context.SaveChangesAsync();

                if (result <= 0)
                {
                    throw new Exception("Error inserting book");
                }

                return Unit.Value;
            }
        }
    }
}
