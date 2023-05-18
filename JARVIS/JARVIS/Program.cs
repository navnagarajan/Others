using JARVIS;
using JARVIS.Option;

Console.Title = $"JARVIS(v0.0.1)";

// Initializing....
DisplayUnit displayUnit = new(SetupManager.OptionModels);

// Reading cmd args
var cmdArgs = Environment.GetCommandLineArgs();

string? key = string.Empty;

// Trying to understand the command line args if available
if (cmdArgs?.Any() == true && cmdArgs.Length == 2)
{
    key = cmdArgs[1]?.Trim()?.ToLower();
}

IOptionResolver resolver = new DefaultOptionResolver();

if (!string.IsNullOrWhiteSpace(key))
{
    var keyResolver = SetupManager.OptionModels.FirstOrDefault(element => element.Resolver.Key == key)?.Resolver;
    if (keyResolver == null)
    {
        return;
    }

    await keyResolver.Resolve();
    return;
}

while (true)
{
    string option = displayUnit.ShowOptions();

    if (option?.ToLower() == "q" || option?.ToLower() == "quit")
    {
        Console.WriteLine("See you later :)");
        break;
    }

    if (!int.TryParse(option ?? string.Empty, out int value) || !SetupManager.OptionModels.Any(A => A.Id == value))
    {
        Console.WriteLine("Please review the option :@");
        option = string.Empty;  // Resetting the option.
        continue;
    }

    resolver = SetupManager.OptionModels.FirstOrDefault(element => element.Id == value)!.Resolver;

    await resolver.Resolve();

    option = string.Empty;  // Resetting the option.
}