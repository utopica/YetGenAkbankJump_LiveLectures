using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Week11_Assignment.Domain.Common;

namespace Week11_Assignment.Domain.Entities
{
    
    public class BankAccount : EntityBase<Guid>
    {
 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Balance { get; set; }

    }
}
