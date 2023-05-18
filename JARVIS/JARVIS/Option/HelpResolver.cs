namespace JARVIS.Option
{
    public class HelpResolver : IOptionResolver
    {
        public string Key => "help";
        public string Name => "Help";
        public string Description => string.Empty;
        public double Version => 1.0;

        public async Task Resolve()
        {
            Console.WriteLine("Available keys");
            Console.ResetColor();
        }
    }
}
