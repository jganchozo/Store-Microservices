using FluentValidation;
using MediatR;
using Store.Api.Author.Model;
using Store.Api.Author.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Api.Author.Application
{
    public class CreateAuthorCommand
    {
        public class Execute : IRequest
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public DateTime? DateOfBirth { get; set; }
        }

        public class ExecuteValidations : AbstractValidator<Execute>
        {
            public ExecuteValidations()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly AuthorContext _context;
            public Handler(AuthorContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                BookAuthor author = new BookAuthor
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    DateOfBirth = request.DateOfBirth,
                    AuthorGuid = Guid.NewGuid().ToString()
                };

                await _context.Author.AddAsync(author);
                var result = await _context.SaveChangesAsync();

                if (result <= 0)
                {
                    throw new Exception("Error inserting uthor");
                }

                return Unit.Value;
            }
        }
    }
}
