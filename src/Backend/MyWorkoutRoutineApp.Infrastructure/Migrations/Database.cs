using Dapper;
using MySqlConnector;

namespace MyWorkoutRoutineApp.Infrastructure.Migrations
{
    public static class Database
    {
        public static void CreateDatabase(string connectionString, string nameDatabase)
        {
            using var myConnection = new MySqlConnection(connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("name", nameDatabase);

            var registers = myConnection.Query("SELECT * FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @name", parameters);

            if (!registers.Any())
            {
                myConnection.Execute($"CREATE DATABASE {nameDatabase}");
            }
        }
    }
}
