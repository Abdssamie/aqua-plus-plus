using System.Collections.Generic;
using AquaPP.Services;
using Avalonia;
using Avalonia.Styling;
using Serilog;

namespace AquaPP.ViewModels.Pages;

public class SettingsViewModel : PageBase
{
    private readonly ILogger _logger;
    private readonly UserPreferencesService _userPreferencesService;
    public List<ThemeVariant> Themes { get; } = new() { ThemeVariant.Light, ThemeVariant.Dark };

    public ThemeVariant SelectedTheme
    {
        get => _userPreferencesService.Preferences.Theme;
        set
        {
            if (_userPreferencesService.Preferences.Theme == value) return;
            _userPreferencesService.Preferences.Theme = value;
            if (Application.Current is not null)
            {
                Application.Current.RequestedThemeVariant = value;
            }
            _userPreferencesService.SavePreferences();
        }
    }

    public SettingsViewModel(ILogger logger, UserPreferencesService userPreferencesService) : base("Settings", "fa-solid fa-gear", 4)
    {
        _logger = logger;
        _userPreferencesService = userPreferencesService;

        SelectedTheme = _userPreferencesService.Preferences.Theme;
    }
}
