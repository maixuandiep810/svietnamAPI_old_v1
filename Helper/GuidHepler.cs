using System;

namespace svietnamAPI.Helper
{
    public static class GuidHepler
    {
        public static string GenerateGuid() {
            var guidString = Guid.NewGuid().ToString();
            return guidString;
        }
    }
}