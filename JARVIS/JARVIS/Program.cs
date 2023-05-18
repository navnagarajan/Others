using JARVIS;
using JARVIS.Option;

Console.Title = $"JARVIS(v0.0.1)";

// Initializing....
SetupManager setupManager = new();

var options = Environment.GetCommandLineArgs();

string? option = string.Empty;

if (options?.Any() == true && options.Length == 2)
{
    option = options[1];
}

while (true)
{
    IOptionResolver? resolver;

    if (string.IsNullOrWhiteSpace(option?.Trim()))
    {
        Console.WriteLine("Options.. \n");

        setupManager.optionModels.ForEach(model =>
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{model.Id}, {model.Name}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\t{model.Description}");
            Console.ResetColor();
        });

        Console.Write("Your choice: ");
        option = Console.ReadLine();

        if (option == "q" || option?.ToLower() == "quit" || option?.ToLower() == "exit")
        {
            break;
        }

        if (!int.TryParse(option, out int value))
        {
            Console.WriteLine($"Invalid option");
            continue;
        }

        resolver = setupManager.optionModels.FirstOrDefault(element => element.Id == value)?.OptionResolver;
    }
    else
    {
        resolver = setupManager.optionModels.FirstOrDefault(element => element.Key == option)?.OptionResolver;
    }

    resolver ??= new DefaultOptionResolver();

    await resolver.Resolve();

    option = null; // Resetting the option.
}