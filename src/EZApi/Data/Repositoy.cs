namespace EZApi.Data;

using Microsoft.EntityFrameworkCore;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class 
{
    public static readonly string query = "SELECT @ATTRIBUTE FROM @TABLE WHERE @CONDITION";

    protected readonly DbContext context;
    public DbSet<TEntity> dbSet { get; set; }

    public Repository(DbContext context)
    {
        this.context = context;
        this.dbSet = context.Set<TEntity>();
    }
    
    public async Task<TEntity?> Get(int id) 
    {
        return await dbSet.FindAsync(id);
    }
    public async Task<TEntity?> Get(params object[] ids)
    {
        return await dbSet.FindAsync(ids);
    }
    
    public async Task<IEnumerable<TEntity?>> GetAll()
    {
        return await dbSet.ToListAsync();
    }
    public async Task<TEntity?> Add(TEntity entity)
    {
        await dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }
    public async Task<TEntity?> Update(TEntity entity)
    {
        dbSet.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }
    public async Task<TEntity?> Delete(int id) 
    {
        var entity = await dbSet.FindAsync(id);
        if (entity == null)
        {
            return null;
        }
        dbSet.Remove(entity);
        await context.SaveChangesAsync();
        return entity;
    }
} 