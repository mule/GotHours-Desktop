using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Tool.hbm2ddl;






namespace GotHoursDAL
{
    public static  class NHibernateHelper
    {
        private static FluentConfiguration _config;
        private static ISessionFactory _factory;


      static NHibernateHelper()
        {
            _config = FluentNHibernate.Cfg.Fluently.Configure().Database(
                MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("GotHoursTestConStr")
                    )).Mappings(m => m.FluentMappings.AddFromAssemblyOf<GotHoursDAL.Mappings.TaskMap>());      
            _factory = _config.BuildSessionFactory();
               
           

            
        }



      public static ISession  OpenSession()
      {

         return _factory.OpenSession();

      }


        public static void GenerateSchema()
        {
            new SchemaExport(_config.BuildConfiguration()).Create(true,true);

        }






    }
}
