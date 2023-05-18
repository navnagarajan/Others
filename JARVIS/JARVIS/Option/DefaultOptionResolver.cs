namespace JARVIS.Option
{
    public class DefaultOptionResolver : IOptionResolver
    {
        public string Key => "default";
        public string Name => "Default";
        public string Description => "";
        public double Version => 1.0;


        public async Task Resolve()
        {
            Console.WriteLine("Option was not matched! :(");
        }
    }
}
