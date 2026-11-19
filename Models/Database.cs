using MySqlConnector;

namespace Smart_match.Models;

public static class Database
{
    public const string ConnectionString =
        "Server=127.0.0.1;Port=3306;Database=smartmatch;User ID=root;Password=;";

    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(ConnectionString);
    }
}