using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GotHoursDAL.Entities;
using FluentNHibernate.Mapping;

namespace GotHoursDAL.Mappings
{
   public class TaskMap : ClassMap<Task>
    {

       public TaskMap()
       {
           Id(x => x.Id);
           Map(x => x.TaskName);
       }

    }
}
