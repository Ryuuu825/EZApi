namespace EZApi.Exceptions
{
    public class ElementsNotFoundException : EZApiException
    {
        public ElementsNotFoundException(string message) : base(message)
        {
        }
    }
}