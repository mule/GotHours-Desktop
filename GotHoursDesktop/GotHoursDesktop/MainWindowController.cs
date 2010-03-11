using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Security.Principal;
using GotHoursDAL.Entities;
using GotHoursDAL;
using NHibernate;



namespace GotHoursDesktop
{
    public class MainWindowController
    {


        private ISession _session = NHibernateHelper.OpenSession();
        private User _currentUser;

        public User CurrentUser
        {
            get { return _currentUser; }

        }
        private Task _currentTask;
        private IList<Task> _listOfTasks = new List<Task>();

        public IList<Task> ListOfTasks
        {
            get { return _listOfTasks; }

        }
 



        public MainWindowController()
        {
            loadUser();
            loadTasks();

        }



        public readonly List<Task> Tasks = new List<Task>();

        private void loadUser(){
  
            string usrName = WindowsIdentity.GetCurrent()!=null ? WindowsIdentity.GetCurrent().Name : "Unknown";

            var usr =
                _session.CreateQuery("from User u where  u.UserName = :username").SetParameter("username", usrName).List
                    <User>();


            if (usr != null && usr.Count >= 1)
                this._currentUser = usr.First();
            else
            {
                this._currentUser = new User();
                _currentUser.UserName = usrName;
                _session.SaveOrUpdate(_currentUser);


            }


        }


        private void loadTasks()
        {
            
            var tasks = _session.CreateQuery(" select distinct Task from TimeLog tl where tl.User = :user ").SetParameter("user",_currentUser).List<Task>();

            if(tasks!=null)
            {

                _listOfTasks = tasks;


            }



        }




        public void LogTime(string pTaskName, DateTime pStartTime, DateTime pEndTime)
        {
            TimeLog tLog = new TimeLog();
            tLog.User = _currentUser;
            tLog.StartTime = pStartTime;
            tLog.EndTime = pEndTime;

            if (_currentTask != null && _currentTask.TaskName == pTaskName)
            {
                tLog.Task = _currentTask;

            }
            else
            {

                _currentTask = getTask(pTaskName);

            }



            tLog.Task = _currentTask;

            _session.SaveOrUpdate(tLog);

            loadTasks();


        }


        private Task getTask(string pTaskName){

            var tsk = (from t in _listOfTasks
                       where t.TaskName == pTaskName
                       select t).FirstOrDefault<Task>();

            if (tsk == null)
            {
                tsk = new Task {TaskName = pTaskName};
                _session.SaveOrUpdate(tsk);
            }


            return tsk;


        }










    }
}
