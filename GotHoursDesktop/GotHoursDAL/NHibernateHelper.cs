using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Diagnostics;






namespace GotHoursDAL
{
    public static class NHibernateHelper
    {
        private static FluentConfiguration _config;
        private static ISessionFactory _factory;


        static NHibernateHelper()
        {
            setupProductionConfig(ref _config, ref _factory);
            setupTestConfig(ref _config,ref _factory);


           
        }



        public static ISession OpenSession()
        {

            return _factory.OpenSession();

        }


        public static void GenerateSchema()
        {
            new SchemaExport(_config.BuildConfiguration()).Create(true, true);

        }

        [Conditional("DEBUG")]
        static void setupTestConfig(ref FluentConfiguration pConfig, ref ISessionFactory pFactory)
        {
            pConfig = FluentNHibernate.Cfg.Fluently.Configure().Database(
   MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("GotHoursTestConStr")
       ).ShowSql()).Mappings(m => m.FluentMappings.AddFromAssemblyOf<GotHoursDAL.Mappings.TaskMap>());
            pFactory = _config.BuildSessionFactory();



        }

        [Conditional("PRODUCTION")]
        static void setupProductionConfig(ref FluentConfiguration pConfig, ref ISessionFactory pFactory)
        {
            pConfig = FluentNHibernate.Cfg.Fluently.Configure().Database(
MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("GotHoursProdConStr")
)).Mappings(m => m.FluentMappings.AddFromAssemblyOf<GotHoursDAL.Mappings.TaskMap>());
            pFactory = _config.BuildSessionFactory();


        }






    }
}
