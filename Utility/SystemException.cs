using System;

namespace Utility
{
    [Serializable]
    public class SystemException : Exception
    {
        public SystemException(string message) : base(message) { }
    }
}
