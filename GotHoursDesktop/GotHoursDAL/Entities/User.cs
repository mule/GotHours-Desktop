using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GotHoursDAL.Entities
{
    public class User
    {
        public virtual int Id { get; private set; }
        public virtual string UserName { get; set; }
        public virtual IList<TimeLog> TimeLogs { get; private set; }

        public User()
        {
            TimeLogs = new List<TimeLog>();
        }
      

    }



}
