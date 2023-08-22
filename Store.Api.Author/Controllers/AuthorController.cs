using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Author.Application;
using Store.Api.Author.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Api.Author.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(CreateAuthorCommand.Execute author)
        {
            return await _mediator.Send(author);
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorDto>>> GetAuthors()
        {
            return await _mediator.Send(new SelectAuthorCommand.GetAuthors());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(string id)
        {
            return await _mediator.Send(new SelectAuthorByIdCommand.GetAuthor() { AuthorGuid = id });
        }
    }
}
