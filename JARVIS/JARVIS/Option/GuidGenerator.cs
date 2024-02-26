namespace JARVIS.Option
{
    public class GuidGenerator : IOptionResolver
    {
        public string Key => "guid";
        public string Name => "GUID";
        public string ShortDescription => "Display New GUID";
        public double Version => 1.0;


        public async Task Resolve(List<string>? pParams = null)
        {
            Guid guid = Guid.NewGuid();
            Console.WriteLine("Guild : {0}", guid);
        }
    }
}
