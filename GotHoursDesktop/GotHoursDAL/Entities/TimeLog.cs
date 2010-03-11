using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GotHoursDAL.Entities
{
    public class TimeLog
    {
        public virtual int Id { get; private set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual User User { get; set; }
        public virtual Task Task { get; set; }




    }
}
