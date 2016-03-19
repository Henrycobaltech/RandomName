using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace RandomName.Services
{
    public static class FileServices
    {
        private static readonly string FileName =
            new AppSettingsReader().GetValue("SourceFileName", typeof(string)).ToString();

        public static IEnumerable<string> GetNames() => File.ReadLines(FileName, new UTF8Encoding());
    }

}

