namespace DS.Core
{
    public static class AppSetting
    {
        public static class Jwt
        {
            public static string Secret { get; set; } = null!;
            public static string Audience { get; set; } = null!;
            public static string Issuer { get; set; } = null!;
        }

        public static class Database
        {
            public static string DataSource { get; set; } = null!;

            public static string Catalog { get; set; } = null!;

            public static string UserName { get; set; } = null!;

            public static string Password { get; set; } = null!;

            public static string TrustedConnection { get; set; } = null!;

            public static string TrustServerCertificate { get; set; } = null!;

            public static string MultipleActiveResultSets { get; set; } = null!;

            public static string IntegratedSecurity { get; set; } = null!;
        }

        public static string[] ValidOrigins { get; set; } = [];
        public static string GetConnectionString()
        {
            //return "Server=" + Database.DataSource + ";Database=" + Database.Catalog + ";User Id=" + Database.UserName + ";Password=" + Database.Password + ";Trusted_Connection=" + Database.TrustedConnection + ";Integrated Security=" + Database.IntegratedSecurity + ";MultipleActiveResultSets=" + Database.MultipleActiveResultSets + ";TrustServerCertificate=" + Database.TrustServerCertificate;
            return "Data Source=localhost\\SQLEXPRESS;Initial Catalog=devsphere;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;";
        }
    }
}
