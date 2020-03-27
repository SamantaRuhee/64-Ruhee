using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string bookName { get; set; }
        public string bookAuthor { get; set; }
        public DateTime publishDate { get; set; }
    }
}
