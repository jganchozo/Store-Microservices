using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.ShoppingCart.RemoteModel
{
    public class RemoteBook
    {
        public Guid BookModelId { get; set; }
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public Guid? AuthorGuid { get; set; }
    }
}
