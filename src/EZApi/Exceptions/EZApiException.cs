namespace EZApi.Exceptions;

public class EZApiException : Exception
{
    public EZApiException(string message) : base(message)
    {
    }
}