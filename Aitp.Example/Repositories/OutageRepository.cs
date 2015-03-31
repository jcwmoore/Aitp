using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aitp.Example.Repositories
{
    public class OutageRepository : IRepository<Outage>, IDisposable
    {  
        #region SQL 

        private const string CREATE_TABLE = "CREATE TABLE IF NOT EXISTS outages (outageId INTEGER PRIMARY KEY AUTOINCREMENT, startTimeUtc INTEGER DEFAULT 0, endTimeUtc INTEGER DEFAULT 0, unitName TEXT);";

        #endregion

        private readonly IDbConnection _connection;

        public OutageRepository(IDbConnection connection)
        {
            _connection = connection;
            _connection.Open(); 
            using (var command = _connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = CREATE_TABLE;
                command.ExecuteNonQuery();
            }
        }

        public ICollection<Outage> Select(ICriteria<Outage> criteria)
        {
            var query = "SELECT * FROM outages";
            var filters = new List<String>();
            foreach (var c in criteria)
            {
                if (c.Restriction == Criteria.StartTimeUtc)
                {
                    filters.Add("startTimeUtc = " + ((DateTime)c.Value).Ticks.ToString());
                }
                if(c.Restriction == Criteria.UnitName)
                {
                    filters.Add("unitName = " + c.Value.ToString());
                }
            }
            if (filters.Count > 0)
            {
                query = string.Format("{0} WHERE {1}", query, string.Join(" AND ", filters));
            }
            var result = new List<Outage>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = query;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var o = new Outage();
                    o.StartTimeUtc = new DateTime((long)reader["startTimeUtc"], DateTimeKind.Utc);
                    o.EndTimeUtc = new DateTime((long)reader["endTimeUtc"], DateTimeKind.Utc);
                    o.UnitName = reader["unitName"].ToString();
                    result.Add(o);
                }
            }
            return result;
        }

        public void Insert(Outage outage)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO outage VALUES (" + outage.StartTimeUtc.Ticks.ToString() + ", " + outage.EndTimeUtc.Ticks.ToString() + ", " + outage.UnitName + ");";
                command.ExecuteNonQuery();
            }
        }

        public void Update(Outage entity)
        {
            throw new InvalidOperationException();
        }

        public void Remove(Outage entity)
        {
            throw new InvalidOperationException();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
