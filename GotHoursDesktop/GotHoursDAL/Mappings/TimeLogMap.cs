using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GotHoursDAL.Entities;
using FluentNHibernate.Mapping;

namespace GotHoursDAL.Mappings
{
    public class TimeLogMap : ClassMap<TimeLog>
    {
        public TimeLogMap()
        {
            Id(x => x.Id);
            Map(x => x.StartTime);
            Map(x => x.EndTime);
            References(x => x.User);
            References(x => x.Task);
        }

    }
}
