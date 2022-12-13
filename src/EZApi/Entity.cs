namespace EZApi 
{
    public class Entity
    {
        public int Id { get; set; }


        // some call back functions before database operations
        // used for validation, and field auto-fill
        public virtual void OnBeforeAdd() { }

        // some call back functions after database operations
        public virtual void OnAfterAdd() { }

    }
}