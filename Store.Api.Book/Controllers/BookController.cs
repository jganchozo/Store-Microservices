using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Book.Application;
using Store.Api.Book.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Api.Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Unit> Create(CreateBookCommand.Execute book)
        {
            return await _mediator.Send(book);
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetBooks()
        {
            return await _mediator.Send(new SelectBookCommand.Execute());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(Guid id)
        {
            return await _mediator.Send(new SelectBookByIdCommand.Execute() { BookModelId = id });
        }

    }
}
