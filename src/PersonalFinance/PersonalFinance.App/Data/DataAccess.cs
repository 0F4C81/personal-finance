using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace PersonalFinance.App.Data
{
    public static class DataAccess
    {
        public static SqlConnection GetSqlConnection()
        {
            string connectionString = Settings.Default.connection_String;
            SqlConnection cs = new SqlConnection(connectionString);
            if (cs.State != ConnectionState.Open) cs.Open();

            return cs;
        }

        public static DataTable Get_DataTable(string query)
        {
            SqlConnection connection = GetSqlConnection();

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(table);

            return table;
        }

        public static void Execute_Query(string query)
        {
            SqlConnection connection = GetSqlConnection();

            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public static void Close_SqlConnection()
        {
            string connectionString = Settings.Default.connection_String;
            SqlConnection connection = new SqlConnection(connectionString);
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
}
