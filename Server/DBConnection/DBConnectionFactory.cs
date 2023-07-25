using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DBConnection
{
    public class DBConnectionFactory
    {
        private static DBConnectionFactory instance;
        private DBConnection connection = new DBConnection();

        public static DBConnectionFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBConnectionFactory();
                }
                return instance;
            }
        }
        private DBConnectionFactory()
        {

        }

        public DBConnection GetDbConnection()
        {
            if (!connection.IsReady())
            {
                connection.OpenConnection();
            }
            return connection;
        }
    }
}
