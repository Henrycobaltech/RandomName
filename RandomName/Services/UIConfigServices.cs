using System.Configuration;

namespace RandomName.Services
{
    public class UIConfigServices
    {
        public static string GetWindowTitle() => new AppSettingsReader().GetValue("WindowTitle", typeof(string)).ToString();
    }
}
