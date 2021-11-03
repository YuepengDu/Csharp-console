using System.IO;

namespace ConnectionLib
{   /// <summary>
/// This Class work with database at the beginning by creating all tables
/// </summary>
    public static class DatabaseCreater
    {
        /// <summary>
        /// Create all tables in database with constrains
        /// </summary>
        /// <param name="connectionString"></param>
        public static void CreateTables(string connectionString)
        {

            using var connection = connectionString.CreateConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = File.ReadAllText("Sql/CreateTables.sql");

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
