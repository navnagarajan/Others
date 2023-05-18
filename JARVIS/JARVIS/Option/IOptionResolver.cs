namespace JARVIS.Option
{
    public interface IOptionResolver
    {
        public double Version { get; }
        public Task Resolve();
    }
}
