using System;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public class DataBase : IDisposable
    {
        private SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\armen\source\repos\WindowsFormsApp1\WindowsFormsApp1\DB.mdf;Integrated Security=True");
        public SqlConnection GetConection { get { return sqlConnection; } }
        public void OpenConnection() { sqlConnection.Open(); }
        public void CloseConnection() { sqlConnection.Close(); }
        static public DataTable runQuery(string query)
        {
            using (var db = new DataBase())
            {
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(query, db.GetConection);
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        public DataBase()
        {
            sqlConnection.Open();
        }

        public void Dispose()
        {
            CloseConnection();

        }

    }
}
