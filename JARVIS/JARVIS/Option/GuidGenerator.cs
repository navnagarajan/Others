namespace JARVIS.Option
{
    public class GuidGenerator : IOptionResolver
    {
        public double Version => 1.0;

        public async Task Resolve()
        {
            Guid guid = Guid.NewGuid();
            Console.WriteLine("Guild : {0}", guid);
        }
    }
}
