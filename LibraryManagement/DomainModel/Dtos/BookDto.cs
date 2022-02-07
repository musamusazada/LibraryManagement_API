using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Dtos
{
    public class BookDto
    {
        public string name { get; set; }
        public string title { get; set; }
        public Author author { get; set; }

        public Genre genre { get; set; }
    }
}
