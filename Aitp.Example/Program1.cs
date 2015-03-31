using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aitp.Example
{
    public class Program1
    {
        public static void Main(string[] args)
        {
            var container = new IoC.Container();

            #region IoC Setup

            container.Register<IDbConnection>().As(c => new System.Data.SQLite.SQLiteConnection("outage.db3"));
            container.Register<IRepository<Outage>>().To<Repositories.OutageRepository>();

            #endregion

            Execute(container);
        }

        public static void Execute(IoC.Container container)
        {
            #region Read Outage from System of Record
            var outage = new Outage();

            #endregion

            #region Send Outage to SharePoint

            #endregion

            #region Save outage to avoid double processing

            var repo = container.Resolve<IRepository<Outage>>();
            repo.Insert(outage);

            #endregion
        }

    }


    public class Program2
    {
        public static void Main(string[] args)
        {
            var container = new IoC.Container();

            #region IoC Setup

            container.Register<IDbConnection>().As(c => new System.Data.SQLite.SQLiteConnection("outage.db3"));
            container.Register<IRepository<Outage>>().To<Repositories.OutageRepository>();

            #endregion

            Execute(container);
        }

        public static void Execute(IoC.Container container)
        {
            #region Read Outage from System of Record
            var outage = new Outage();

            #endregion

            #region Send Outage to SharePoint

            #endregion

            #region Save outage to avoid double processing

            var repo = container.Resolve<IRepository<Outage>>();
            try
            {
                repo.Insert(outage);
            }
            catch (Exception e)
            {
                EmailProgrammers(e.Message);
            }

            #endregion
        }

        static void EmailProgrammers(string message)
        {

        }
    }
}
