using JARVIS.Model;
using JARVIS.Option;

namespace JARVIS
{
    public sealed class SetupManager
    {
        public static readonly List<OptionModel> OptionModels = new()
        {
            new OptionModel
            {
                Id = 1,
                Resolver = new NginxConfiguration()
            },
            new OptionModel
            {
                Id = 2,
                Resolver = new DatabaseConfiguration()
            },
            new OptionModel
            {
                Id = 3,
                Resolver = new RandomPassword()
            },
            new OptionModel
            {
                Id = 4,
                Resolver = new SqlLoginCredentials()
            },
             new OptionModel
            {
                Id = 5,
                Resolver = new GuidGenerator()
            },
             new OptionModel
            {
                Id = 6,
                Resolver = new HelpResolver()
            },
            new OptionModel
            {
                Id = 7,
                Resolver = new ScreenshotManager()
            },
        };

        private SetupManager()
        {
        }
    }
}
