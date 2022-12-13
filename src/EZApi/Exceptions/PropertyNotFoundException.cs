namespace EZApi.Exceptions;

public class PropertyNotFoundException : EZApiException
{
    public PropertyNotFoundException(string message) : base(message)
    {
    }
}