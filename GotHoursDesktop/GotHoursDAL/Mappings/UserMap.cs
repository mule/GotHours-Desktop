using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GotHoursDAL.Entities;
using FluentNHibernate.Mapping;

namespace GotHoursDAL.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.UserName);
            HasMany<TimeLog>(x => x.TimeLogs);


        }
    }
}
