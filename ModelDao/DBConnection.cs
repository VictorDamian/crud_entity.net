using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDao
{
    class DBConnection
    {
        // Singleton
        private static DBConnection dBConnection = null;
        private SqlConnection sqlConnection;
        private DBConnection()
        {
            sqlConnection = new SqlConnection("Data Source=DANTES\\DANTES;Initial Catalog=SCHOOL;Integrated Security=True");
        }
        public static DBConnection stateConnection()
        {
            if(dBConnection == null)
            {
                dBConnection = new DBConnection();
            }
            return dBConnection;
        }
        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
        public void closeConnection()
        {
            dBConnection = null;
        }
    }
}
