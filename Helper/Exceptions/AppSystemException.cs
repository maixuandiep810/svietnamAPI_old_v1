using System;
using System.Reflection;

namespace svietnamAPI.Helper.Exceptions
{
    public class AppSystemException : Exception
    {
        public AppSystemException(Exception ex) : base()
        {
            var stackTraceField = typeof(AppSystemException)
                .BaseType
                .GetField("_stackTraceString", BindingFlags.Instance | BindingFlags.NonPublic);
            stackTraceField.SetValue(this, ex.StackTrace);
        }
    }
}