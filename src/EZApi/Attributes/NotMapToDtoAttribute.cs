namespace EZApi.Attributes
{
    // Not Map to Input DTO AND Output DTO
    [AttributeUsage(AttributeTargets.Property)]
    public class NotMapToDtoAttribute : System.Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class NotMapToODtoAttribute : System.Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class NotMapToIDtoAttribute : System.Attribute
    {
    }
}

