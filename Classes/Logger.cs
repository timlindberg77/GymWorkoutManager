using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace GymWorkoutManager.Classes
{
    public class Logger
    {
        private readonly string _filePath = Path.Combine(GetProjectDirectory(), "log.json");
        private List<string> _errors = new();

        public Logger()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string json = File.ReadAllText(_filePath);
                    _errors = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
                }
            }
            catch (Exception)
            {
                // trasig eller tom fil: börja med en tom lista
            }
        }
        public void LogError(string message)
        {
            _errors.Add($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {message}");

            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                File.WriteAllText(_filePath, JsonSerializer.Serialize(_errors, options));
            }
            catch (Exception)
            {
                // loggern får aldrig krascha programmet
            }
        }

        // hittar projektmappen så att log.json inte hamnar i bin
        private static string GetProjectDirectory()
        {
            var dir = new DirectoryInfo(AppContext.BaseDirectory);
            while (dir != null && dir.GetFiles("*.csproj").Length == 0)
                dir = dir.Parent;

            return dir?.FullName ?? AppContext.BaseDirectory;
        }
    }
}
