using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week13_2.Domain.Common;

namespace Week13_2.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }

        public decimal Price { get; set; }  
    }
}
