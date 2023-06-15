using JARVIS.Model;

namespace JARVIS
{
    public class DisplayUnit
    {
        private readonly List<OptionModel> _optionModel;
        public DisplayUnit(List<OptionModel> optionModel)
        {
            _optionModel = optionModel;
        }

        public string ShowOptions()
        {
            _optionModel.ForEach(model =>
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{model.Id}, {model.Resolver.Name}");

                if (!string.IsNullOrWhiteSpace(model.Resolver.ShortDescription))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"# {model.Resolver.ShortDescription}");
                }
            });

            Console.ResetColor();
            Console.Write("Your choice (q/quit): ");
            var option = Console.ReadLine() ?? string.Empty;
            return option;
        }
    }
}
