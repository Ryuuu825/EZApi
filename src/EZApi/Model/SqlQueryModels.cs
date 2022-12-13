namespace EZApi.Model;
public class SqlQueryModel {


    /*
     * The attributes that are returned by the query
     * "SELECT @{ReturnedAttributes} FROM @TABLE WHERE @CONDITION"
     */
    public ICollection<string> ReturnedAttributes { get; set; } = new List<string>();

    // A collection of conditions to be used in the query
    // Example: "id = 1"
    // This is provided by the user, because users may want to use = / != / > / < / >= / <=
    // In the previous version, I expected all condition are =, which is not flexible
    public ICollection<string> Conditions { get; set; } = new List<string>();

}