namespace JARVIS.Option
{
    public class DatabaseConfiguration : IOptionResolver
    {
        private const string CreateDbTemplate = @"CREATE DATABASE {@DB_NAME};";
        private const string CreateNewDbUserTemplate = "CREATE USER '{@DB_USER_NAME}'@'%' IDENTIFIED BY '{@DB_USER_PASSWORD}';";
        private const string GrantUserPermissionTemplate = "GRANT SELECT, INSERT, CREATE, ALTER, DROP, LOCK TABLES, CREATE TEMPORARY TABLES, DELETE, UPDATE, EXECUTE ON {@DB_NAME}.* TO'{@DB_USER_NAME}'@'%';";

        public double Version => 1.0;

        public async Task Resolve()
        {
            Console.Write("Database name : ");
            string? dbName = Console.ReadLine();

            Console.Write("Database username : ");
            string? dbUserName = Console.ReadLine();

            Console.Write("Database password (leave empty for random password): ");
            string? dbUserPassword = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(dbUserPassword))
            {
                dbUserPassword = RandomPassword.Generate();
            }

            if (string.IsNullOrWhiteSpace(dbName) || string.IsNullOrWhiteSpace(dbUserName) || string.IsNullOrWhiteSpace(dbUserPassword))
            {
                return;
            }

            Console.WriteLine(CreateDbTemplate.Replace("{@DB_NAME}", dbName));
            Console.WriteLine(CreateNewDbUserTemplate.Replace("{@DB_USER_NAME}", dbUserName).Replace("{@DB_USER_PASSWORD}", dbUserPassword));
            Console.WriteLine(GrantUserPermissionTemplate.Replace("{@DB_NAME}", dbName).Replace("{@DB_USER_NAME}", dbUserName));
        }

    }
}
