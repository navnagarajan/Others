using JARVIS.Option;

namespace JARVIS.Model
{
    public class OptionModel
    {
        public int Id { get; set; }
        public string Key { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IOptionResolver OptionResolver { get; set; } = new DefaultOptionResolver();
    }
}
