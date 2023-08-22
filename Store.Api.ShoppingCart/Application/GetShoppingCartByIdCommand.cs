using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.Api.ShoppingCart.DTOs;
using Store.Api.ShoppingCart.Persistence;
using Store.Api.ShoppingCart.RemoteInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Api.ShoppingCart.Application
{
    public class GetShoppingCartByIdCommand
    {
        public class Execute:IRequest<ShoppingCartDto>
        {
            public int ShoppingCartId { get; set; }
        }

        public class Handler : IRequestHandler<Execute, ShoppingCartDto>
        {
            private readonly IBookService _bookService;
            private readonly ShoppingCartContext _context;

            public Handler(IBookService bookService, ShoppingCartContext context)
            {
                _bookService = bookService;
                _context = context;
            }

            public async Task<ShoppingCartDto> Handle(Execute request, CancellationToken cancellationToken)
            {
                var session = await _context.ShoppingCartSession.FirstOrDefaultAsync(x => x.ShoppingCartSessionId == request.ShoppingCartId);
                var detail = await _context.ShoppingCartSessionDetail.Where(x => x.ShoppingCartSessionId == request.ShoppingCartId).ToListAsync();

                var shoppingCartListDto = new List<ShoppingCartDetailDto>();

                foreach (var book in detail)
                {
                    var response = await _bookService.GetBook(new Guid(book.SelectedProduct));

                    if (response.result)
                    {
                        var bookObject = response.book;
                        var shoppingCartDetail = new ShoppingCartDetailDto()
                        {
                            BookTitle = bookObject.Title,
                            PublicationDate = bookObject.PublicationDate,
                            BookId = bookObject.BookModelId
                        };

                        shoppingCartListDto.Add(shoppingCartDetail);
                    }
                }

                var ShoppingCartDto = new ShoppingCartDto()
                {
                    ShoppingCartId = session.ShoppingCartSessionId,
                    CreationDate = session.CreationDate,
                    ProductList = shoppingCartListDto
                };

                return ShoppingCartDto;
            }
        }
    }
}
