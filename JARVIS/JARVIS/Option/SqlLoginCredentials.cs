namespace JARVIS.Option
{
    public class SqlLoginCredentials : IOptionResolver
    {
        private const string template = @"CREATE LOGIN [{@USERNAME}] WITH PASSWORD = '{@PASSWORD}'
CREATE USER [{@USERNAME}] FOR LOGIN [{@USERNAME}]  WITH DEFAULT_SCHEMA =[dbo];
ALTER ROLE {@ROLE} ADD MEMBER[{@USERNAME}]";
        public string Key => "sql-login";
        public string Name => "SQL Login";
        public string ShortDescription => "Generate sql login with username and password with dbo schema.";
        public double Version => 1.0;

        public async Task Resolve(List<string>? pParams = null)
        {
            Console.WriteLine(template);
        }
    }
}
