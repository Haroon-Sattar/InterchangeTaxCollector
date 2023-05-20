namespace Domain.Exceptions
{
    public class UnknownException: Exception
    {
        public UnknownException(string exMessage)
        : base($"Unknown Exception: {exMessage}")
        {
        }
    }
}
