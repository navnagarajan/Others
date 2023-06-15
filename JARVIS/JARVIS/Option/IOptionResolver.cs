namespace JARVIS.Option
{
    public interface IOptionResolver
    {
        public string Key { get; }
        public string Name { get; }
        public string ShortDescription { get; }
        public double Version { get; }
        public Task Resolve();
    }
}
