using Avalonia.Styling;

namespace AquaPP.Models
{
    public class UserPreferences
    {
        public string Language { get; set; } = "en-US";
        public bool EnableNotifications { get; set; } = true;
        public int DataRefreshIntervalMinutes { get; set; } = 15;
        public ThemeVariant Theme { get; set; } = ThemeVariant.Default;
        // Add more preference properties as needed
    }
}
