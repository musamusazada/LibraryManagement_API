using DomainModel.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Genre : IEntity
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
