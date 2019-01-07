using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Linerath_Blog.DAL.Repositories
{
    public class DapperBaseRepository
    {
        private String connectionString;

        public DapperBaseRepository(String connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Execute(Action<IDbConnection> query)
        {
            using (var db = new SqlConnection(connectionString))
            {
                query(db);
            }
        }
    }
}
