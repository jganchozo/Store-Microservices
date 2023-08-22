using Store.Api.ShoppingCart.RemoteModel;
using System;
using System.Threading.Tasks;

namespace Store.Api.ShoppingCart.RemoteInterface
{
    public interface IBookService
    {
        Task<(bool result, RemoteBook book, string ErrorMessage)> GetBook(Guid BookId);
    }
}
