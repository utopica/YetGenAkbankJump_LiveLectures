using RedoMusicMarket.Domain.Common;
using RedoMusicMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoMusicMarket.Domain.Entities
{
    public class Instrument : EntityBase<Guid>
    {
       public string Name { get; set; }
       public string Model { get; set; }
       public Brand Brand { get; set; }
       public decimal Price { get; set; }
       public Color Color { get; set; }
       public DateTime? ProductionYear { get; set; }

        //Category 

    }
}
