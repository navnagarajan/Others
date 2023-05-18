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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{model.Id}, {model.Resolver.Name} [{model.Resolver.Key}]");

                if (!string.IsNullOrWhiteSpace(model.Resolver.Description))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"  > {model.Resolver.Description}");
                }
            });

            Console.ResetColor();
            Console.Write("Your choice (q/quit): ");
            var option = Console.ReadLine() ?? string.Empty;
            return option;
        }
    }
}
