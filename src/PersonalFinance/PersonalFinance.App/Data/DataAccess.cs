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
            SqlConnection connection = new SqlConnection(connectionString);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            return connection;
        }

        public static DataTable ExecuteSelectCommand(SqlConnection connection, CommandType commandType, string query)
        {
            DataTable table = new DataTable();

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand command = connection.CreateCommand();
            command.CommandType = commandType;
            command.CommandText = query;
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                using (adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            return table;
        }

        public static DataTable ExecuteSelectCommandWithParameters(SqlConnection connection, CommandType commandType, string query, SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand();
            DataTable table = new DataTable();

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            command = connection.CreateCommand();
            command.CommandType = commandType;
            command.CommandText = query;

            command.Parameters.AddRange(parameters);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                using (adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Dispose();
                connection.Close();
            }
            return table;
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
