using System;
using System.Reflection;

namespace svietnamAPI.Helper.Exceptions
{
    public class EntityPermissionException : Exception
    {
        public EntityPermissionException() : base() {

        }
        
        public EntityPermissionException(Exception ex) : base()
        {
            var stackTraceField = typeof(AppJwtTokenException)
                .BaseType
                .GetField("_stackTraceString", BindingFlags.Instance | BindingFlags.NonPublic);
            stackTraceField.SetValue(this, ex.StackTrace);
        }
    }
}