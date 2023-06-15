using JARVIS.Utils;

namespace JARVIS.Option
{
    public class ScreenshotManager : IOptionResolver
    {
        public string Key => "ssm";

        public string Name => "Screenshot Manager";

        public string ShortDescription => "Process your screenshots and align those";

        public double Version => 1.0;

        public async Task Resolve()
        {
            try
            {
                string sourceDirectoryPath = AppConstants.ScreenshotManagerConfig?.SourceDirectory?.Trim() ?? string.Empty;
                string destinationDirectoryPath = AppConstants.ScreenshotManagerConfig?.DestinationDirectory?.Trim() ?? string.Empty;
                string rawFilter = AppConstants.ScreenshotManagerConfig?.NameFilter?.Trim() ?? string.Empty;
                string substitute = AppConstants.ScreenshotManagerConfig?.Substitute?.Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(sourceDirectoryPath))
                {
                    Console.WriteLine("Source directory not specified, Ignoring...");
                    return;
                }

                if (string.IsNullOrWhiteSpace(destinationDirectoryPath))
                {
                    Console.WriteLine("Destination directory not specified, Ignoring...");
                    return;
                }

                if (string.IsNullOrWhiteSpace(substitute))
                {
                    Console.WriteLine("Substitute not specified, Ignoring...");
                    return;
                }

                DirectoryInfo sourceDirectory = new(sourceDirectoryPath);

                FileInfo[] files = sourceDirectory.GetFiles("*.png");

                List<string> filterCriteria = new();

                if (!string.IsNullOrWhiteSpace(rawFilter))
                {
                    filterCriteria = rawFilter.Split(',').ToList();
                }

                var unmodifiedFiles = files.Where(W => filterCriteria.Any(A => W.Name.Contains(A)))?.ToList();

                if (unmodifiedFiles?.Any() != true)
                {
                    Console.WriteLine("No files found to align");
                    Console.WriteLine($"Searched directory : {sourceDirectoryPath}");
                    return;
                }

                if (Directory.Exists(destinationDirectoryPath) != true)
                {
                    Directory.CreateDirectory(destinationDirectoryPath);
                }

                foreach (FileInfo file in unmodifiedFiles)
                {
                    string formattedFileName = file.Name.Replace(" ", substitute)
                    .Replace("-", substitute)
                    .Replace("(", substitute)
                    .Replace(")", substitute)
                    .Replace($"{substitute}{substitute}", substitute)
                    .Replace($"{substitute}{substitute}{substitute}", substitute)
                    .ToLower();


                    string folderNameYear = $"{file.CreationTime:yyyy}";
                    string targetDir = Path.Join(destinationDirectoryPath, folderNameYear);

                    if (Directory.Exists(targetDir) != true)
                    {
                        Directory.CreateDirectory(targetDir);
                    }


                    targetDir = Path.Join(targetDir, $"{file.CreationTime:MM} - {file.CreationTime:MMMM}");

                    if (Directory.Exists(targetDir) != true)
                    {
                        Directory.CreateDirectory(targetDir);
                    }

                    string targetPath = Path.Join(targetDir, formattedFileName);

                    if (Directory.Exists(targetPath))
                    {
                        Console.WriteLine($"File '{formattedFileName}' already exist, Ignoring...");
                        continue;
                    }

                    Console.WriteLine($"Src : {file.FullName}, Target : {targetPath}");

                    File.Move(file.FullName, targetPath);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error occurred");
                Console.WriteLine(exception);
            }
        }
    }
}
