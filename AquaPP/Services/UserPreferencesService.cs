using System;
using System.IO;
using System.Text.Json;
using AquaPP.Models;

namespace AquaPP.Services;

public class UserPreferencesService
{
    private readonly string _filePath;
    private UserPreferences _preferences;

    public UserPreferencesService()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        _filePath = Path.Join(path, "user-preferences.json");

        LoadPreferences();
    }

    public UserPreferences Preferences => _preferences;

    private void LoadPreferences()
    {
        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            _preferences = JsonSerializer.Deserialize<UserPreferences>(json);
        }
        else
        {
            _preferences = new UserPreferences();
        }
    }

    public void SavePreferences()
    {
        var json = JsonSerializer.Serialize(_preferences);
        File.WriteAllText(_filePath, json);
    }
}
