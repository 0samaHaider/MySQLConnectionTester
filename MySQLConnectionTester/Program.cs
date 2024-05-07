using Npgsql;
using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MySQLConnectionTester
{
    internal class Program
    {
        static async Task Main()
        {
            // PostgreSQL (Npgsql) Connection
            var pgConnectionString = "Host=abc.web-hosting.com;Username=abc;Password=@abc;Database=abc;";
            await TestPostgreSqlConnection(pgConnectionString);

            // MySQL Connection
            var mySqlConnectionString = "Server=abc.web-hosting.com;Username=abc;Password=@abc;Database=abc;";
            await TestMySqlConnection(mySqlConnectionString);

            Console.ReadLine();
        }

        static async Task TestPostgreSqlConnection(string connectionString)
        {
            await using var conn = new NpgsqlConnection(connectionString);
            try
            {
                await conn.OpenAsync();
                Console.WriteLine(conn.State == System.Data.ConnectionState.Open
                    ? "PostgreSQL Connection opened successfully!"
                    : "PostgreSQL Connection failed to open!");
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"PostgreSQL Error: {ex.Message}");
            }
        }

        static async Task TestMySqlConnection(string connectionString)
        {
            await using var conn = new MySqlConnection(connectionString);
            try
            {
                await conn.OpenAsync();
                Console.WriteLine(conn.State == System.Data.ConnectionState.Open
                    ? "MySQL Connection opened successfully!"
                    : "MySQL Connection failed to open!");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error: {ex.Message}");
            }
        }
    }
}
