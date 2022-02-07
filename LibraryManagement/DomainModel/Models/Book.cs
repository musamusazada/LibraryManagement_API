using DomainModel.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Book : IEntity
    {
        public int id { get; set; }
        public string title { get; set; }
        public Author author { get; set; }

        public Genre genre { get; set; }
    }
}
