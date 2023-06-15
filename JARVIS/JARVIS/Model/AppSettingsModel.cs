namespace JARVIS.Model
{
    public class AppSettingsModel
    {
        public ScreenshotManagerConfig ScreenshotManagerConfig { get; set; } = new();
    }

    public class ScreenshotManagerConfig
    {
        public string NameFilter { get; set; } = string.Empty;
        public string Substitute { get; set; } = string.Empty;
        public string SourceDirectory { get; set; } = string.Empty;
        public string DestinationDirectory { get; set; } = string.Empty;
    }
}
