using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10_1.Domain.Dtos
{
    public class ProductAddDto
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
    }
}
