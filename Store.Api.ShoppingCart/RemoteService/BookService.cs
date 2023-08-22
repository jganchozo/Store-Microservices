using Microsoft.Extensions.Logging;
using Store.Api.ShoppingCart.RemoteInterface;
using Store.Api.ShoppingCart.RemoteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Api.ShoppingCart.RemoteService
{
    public class BookService : IBookService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<BookService> _logger;

        public BookService(IHttpClientFactory httpClientFactory, ILogger<BookService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<(bool result, RemoteBook book, string ErrorMessage)> GetBook(Guid BookId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Books");
                var response = await client.GetAsync($"api/book/{BookId}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    RemoteBook book = JsonSerializer.Deserialize<RemoteBook>(content, options);

                    return (true, book, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return (false, null, ex.Message);
            }
        }
    }
}
