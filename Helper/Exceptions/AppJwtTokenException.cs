using System;
using System.Reflection;

namespace svietnamAPI.Helper.Exceptions
{
    public class AppJwtTokenException : Exception
    {
        public AppJwtTokenException(Exception ex) : base()
        {
            var stackTraceField = typeof(AppJwtTokenException)
                .BaseType
                .GetField("_stackTraceString", BindingFlags.Instance | BindingFlags.NonPublic);
            stackTraceField.SetValue(this, ex.StackTrace);
        }
    }
}