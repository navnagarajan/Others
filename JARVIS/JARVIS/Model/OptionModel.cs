using JARVIS.Option;

namespace JARVIS.Model
{
    public class OptionModel
    {
        public int Id { get; set; }
        public IOptionResolver Resolver { get; set; } = new DefaultOptionResolver();
    }
}
