using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10_1.Domain.Entities;

namespace Week10_1.Domain.Identity
{
    public class UserSetting : EntityBase<Guid>
    {
        // every user should have user setting
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Int16 TimeZone {  get; set; }
        public string LanguageCode { get; set; }

    }
}
