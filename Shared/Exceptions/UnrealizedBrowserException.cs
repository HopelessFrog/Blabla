namespace Shared.Exceptions
{
    public class UnrealizedBrowserException : Exception
    {
        public UnrealizedBrowserException()
        {
        }

        public UnrealizedBrowserException(string message)
            : base(message)
        {
        }

        public UnrealizedBrowserException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
