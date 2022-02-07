using DomainModel.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Author : IEntity
    {
        public int id { get; set; }
        public string fullName { get; set; }

    }
}
