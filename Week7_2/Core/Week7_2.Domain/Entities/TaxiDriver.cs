﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7_2.Domain.Common;

namespace Week7_2.Domain.Entities
{
    public class TaxiDriver : Person
    {
        public string LicencePlate { get; set; }
    }
}
