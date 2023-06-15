namespace JARVIS.Option
{
    public class HelpResolver : IOptionResolver
    {
        public string Key => "help";
        public string Name => "Help";
        public string ShortDescription => "Display available options";
        public double Version => 1.0;

        public async Task Resolve()
        {
            Console.WriteLine("Available keys");

            foreach (var option in SetupManager.OptionModels)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{option.Resolver.Name}");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($" [{option.Resolver.Key}] ");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" (v{option.Resolver.Version.ToString("0.0")})");

                Console.WriteLine($"# {option.Resolver.ShortDescription}");
                Console.WriteLine();
            }

            Console.ResetColor();
        }
    }
}
