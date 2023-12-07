using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoMusicMarket.Domain.Common
{
    public class EntityBase<TKey> : ICreatedOn, IModifiedOn, IDeletedOn
    {
        public TKey Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }

        //? makes nullable
    }
}
