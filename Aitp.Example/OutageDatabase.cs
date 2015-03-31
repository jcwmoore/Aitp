using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Aitp.Example
{
    public class OutageDatabase
    {
        #region SQL 

        private const string CREATE_TABLE = "CREATE TABLE IF NOT EXISTS outages (outageId INTEGER PRIMARY KEY AUTOINCREMENT, startTimeUtc INTEGER, endTimeUtc INTEGER, unitName TEXT);";

        #endregion


        public OutageDatabase()
        {
            using (var connection = new SQLiteConnection("outages.db3"))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = CREATE_TABLE;
                command.ExecuteNonQuery();
            }
        }

        public void InsertOutage(Outage o)
        {
            using (var connection = new SQLiteConnection("outages.db3"))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "INSERT INTO outage VALUES (" + o.StartTimeUtc.Ticks.ToString() + ", " + o.EndTimeUtc.Ticks.ToString() + ", " + o.UnitName + ");";
                command.ExecuteNonQuery();
            }
        }

        public bool OutageExists(Outage o)
        {
            using (var connection = new SQLiteConnection("outages.db3"))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT 1 FROM outages WHERE startTimeUtc = " + o.StartTimeUtc.Ticks.ToString() + " AND unitName = '" + o.UnitName + "';";
                return command.ExecuteScalar() != null;
            }

        }
    }
}
