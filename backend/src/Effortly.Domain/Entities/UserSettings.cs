namespace Effortly.Domain.Entities;

public class UserSettings
{
    public string PreferredUnits { get; set; } = "metric"; // metric or imperial
    public string Language { get; set; } = "en";
    public bool NotificationsEnabled { get; set; } = true;
    public bool DarkMode { get; set; } = false;
    public int RestTimerDefault { get; set; } = 90; // seconds
    public DayOfWeek WeekStartsOn { get; set; } = DayOfWeek.Monday;
}