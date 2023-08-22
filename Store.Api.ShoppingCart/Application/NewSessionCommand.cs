using MediatR;
using Store.Api.ShoppingCart.Model;
using Store.Api.ShoppingCart.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Api.ShoppingCart.Application
{
    public class NewSessionCommand
    {
        public class Execute : IRequest
        {
            public DateTime? CreationDate { get; set; }
            public List<string> ProductList { get; set; }
        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly ShoppingCartContext _context;

            public Handler(ShoppingCartContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var session = new ShoppingCartSession()
                {
                    CreationDate = request.CreationDate
                };

                _context.ShoppingCartSession.Add(session);

                var value = await _context.SaveChangesAsync();

                if (value <= 0)
                {
                    throw new Exception("Error inserting a new session");
                }

                int id = session.ShoppingCartSessionId;

                foreach (string item in request.ProductList)
                {
                    var sessionDetail = new ShoppingCartSessionDetail
                    {
                        ShoppingCartSessionId = id,
                        CreationDate = DateTime.Now,
                        SelectedProduct = item
                    };

                    _context.ShoppingCartSessionDetail.Add(sessionDetail);
                }

                value = await _context.SaveChangesAsync();

                if (value <= 0)
                {
                    throw new Exception("Error inserting detail session");
                }

                return Unit.Value;
            }
        }

    }
}
