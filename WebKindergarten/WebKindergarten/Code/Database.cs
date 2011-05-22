using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.IO;
using WebKindergarten.Code.Entities;

namespace WebKindergarten.Code
{
    public class Database
    {
        //private const string DbFile = "C:\\Users\\Karotte\\Desktop\\NHIBTest\\src\\firstProgram.db";
        //private const string DbFile = "C:\\Users\\David\\Desktop\\Projects\\firstProgram.db";
        private const string DbFile = "firstProgram.db";
        private ISessionFactory sessionFactory;

        public Database()
        {            
            // create our NHibernate session factory
            sessionFactory = CreateSessionFactory();

            /*using (var session = sessionFactory.OpenSession())
            {
                // populate the database
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(new Kind { Vorname = "Jorg", Nachname = "Sander", Geburtstag = new DateTime(1999, 7, 25) });
                    session.SaveOrUpdate(new Kind { Vorname = "Bort", Nachname = "Offl", Geburtstag = new DateTime(2003, 12, 11) });

                    transaction.Commit();
                }
            }*/
        }

        public IList<Kind> getChildList(){
            IList<Kind> result = null;
            using (var session = sessionFactory.OpenSession())
            {
                // retreive all stores and display them
                using (session.BeginTransaction())
                {
                    result = session.CreateCriteria(typeof(Kind))
                        .List<Kind>();
                }
            }
            return result;
        }

        public void addChild(Kind k)
        {
            using (var session = sessionFactory.OpenSession())
            {
                // retreive all stores and display them
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(k);
                    transaction.Commit();
                }
            }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            /*return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                    .UsingFile(DbFile))
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<Database>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();*/

            return Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                    .ConnectionString(cs => cs
                        .Server("192.168.1.11")
                        .Database("testuser")
                        .Username("testuser")
                        .Password("test")))
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<Database>())
                //.ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            //if (File.Exists(DbFile))
            //    File.Delete(DbFile);

            if (File.Exists(DbFile)) return;

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
                .Create(false, true);
        }
    }
}