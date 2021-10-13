using System.Text.RegularExpressions;

namespace svietnamAPI.Helper
{
    public static class RegexHelper
    {
        public static string StandardizeFilename(string filename)
        {
            filename = Regex.Replace(filename, "[^a-zA-Z0-9_/-]+", "", RegexOptions.Compiled);
            return filename;
        }
    }
}