using System;
using System.Collections.Generic;

namespace Store.Api.Author.Model
{
    public class BookAuthor
    {
        public int BookAuthorId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ICollection<Degree> DegreeList { get; set; }
        public string AuthorGuid { get; set; }
    }
}
