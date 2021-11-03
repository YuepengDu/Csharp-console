using System.Data;
using Microsoft.Data.SqlClient;
namespace ConnectionLib
{   /// <summary>
///  This class is used to create connection to database
/// </summary>
    public static class ConnectService
    {
        //Create connection to database
        public static SqlConnection CreateConnection(this string connectionString) =>
            new SqlConnection(connectionString);
        //Get desired table from database based on command
        public static DataTable GetDataTable(this SqlCommand command)
        {
            var table = new DataTable();
            new SqlDataAdapter(command).Fill(table);

            return table;
        }
    }
}
