using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GotHoursDAL.Entities
{
    public class Task
    {
        public virtual int Id { get; private set; }
        public virtual string TaskName { get; set; }
        public virtual IList<TimeLog> TimeLogs { get; private set; }

        public Task()
        {
            TimeLogs = new List<TimeLog>();
            
        }



        public override string ToString()
        {
            return this.TaskName;
        }


       
    }
}
