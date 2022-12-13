namespace EZApi.Model;

public class UpdateEntityModels
{
    public ICollection<UpdateObjectModel> datas { get; set; } = new List<UpdateObjectModel>();

    public class UpdateObjectModel
    {
       public string Attribute { get; set; } = string.Empty;

       #pragma warning disable CS8625
       public object NewValue { get; set; } = null;

       #pragma warning restore CS8625


    }
}

