using JARVIS.Model;
using JARVIS.Option;

namespace JARVIS
{
    public sealed class SetupManager
    {
        public List<OptionModel> optionModels = new()
        {
            new OptionModel
            {
                Id = 0,
                Key = "nginx-config",
                Name = "NGINX Configurations",
                Description = "Preparing NGINX configurations",
                OptionResolver = new NginxConfiguration()
            },
            new OptionModel
            {
                Id = 0,
                Key = "db-config",
                Name = "Database Configurations",
                Description = "Preparing new database create query, new user create query and user login permission query.",
                OptionResolver = new DatabaseConfiguration()
            },
            new OptionModel
            {
                Id = 0,
                Key = "rnd-psw",
                Name = "Random Password",
                Description = "Create a random password based on required length",
                OptionResolver = new RandomPassword()
            },
            new OptionModel
            {
                Id = 0,
                Key = "sql-login",
                Name = "SQL Login",
                Description = "Create new SQL user login query and SQL user permission",
                OptionResolver = new SqlLoginCredentials()
            },
             new OptionModel
            {
                Id = 0,
                Key = "new-guid",
                Name = "New Guid",
                Description = "Generate new guid",
                OptionResolver = new GuidGenerator()
            },
        };

        public SetupManager()
        {
            int index = 1;
            optionModels.ForEach(element =>
            {
                element.Id = index;
                index++;
            });
        }
    }
}
