namespace EZApi.Data;

public interface IRepository<T> where T : class
{
    public Task<T?> Get(int id);
    public Task<T?> Get(params object[] ids);
    // public Task<IEnumerable<T?>> Get(EZApi.Model.UpdateEntityModels sqlQuery );
    public Task<IEnumerable<T?>> GetAll();
    public Task<T?> Add(T entity);
    public Task<T?> Update(T entity);
    public Task<T?> Delete(int id);
}