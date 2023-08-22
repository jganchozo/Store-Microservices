using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Author.Model
{
    public class Degree
    {
        public int DegreeId { get; set; }
        public string Name { get; set; }
        public string Institution { get; set; }
        public DateTime Date { get; set; }
        public int BookAuthorId { get; set; }
        public BookAuthor Author { get; set; }
        public string DegreeGuid { get; set; }
    }
}
