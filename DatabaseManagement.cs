using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibraryBuild.MyClass
{
    public class DatabaseManagement
    {
        public static void SaveData(Database database,string connectionString,string query)
        {
        if (database==Database.MySql)
	{
            //server=127.0.0.1;username=root;password=admin;database=tom;
		MySqlConnection connection = new MySqlConnection(connectionString);

	}
        }
    }

    enum Database
    {
        MySql,
        SqlServer
    }
}
