namespace DS.Core
{
    public class AppSettings
    {
        public static class Database 
        {
            public static string Server { get; set; } = null!;
            public static string Port { get; set; } = null!;
            public static string Name { get; set; } = null!;
            public static string Username { get; set; } = null!;
            public static string Password { get; set; } = null!;

        }

        public static string GetConnectionString()
        {
            return $"Host={Database.Server};Port={Database.Port};Database={Database.Name};User Id={Database.Username};Password={Database.Password};";
        }
    }
}