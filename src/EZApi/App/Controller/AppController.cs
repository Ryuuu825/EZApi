namespace EZApi.App.Controller;

using Microsoft.EntityFrameworkCore;

using EZApi.Data;
using EZApi.Model;
using EZApi.Exceptions;

public class AppController <TEntity, IDtoT, ODtoT> 
    where IDtoT : class // Input DTO
    where ODtoT : class // Output DTO 
    // where TEntity is subclass of Entity
    where TEntity : Entity, new()
{
    private readonly DbContext context;
    private readonly IRepository<TEntity> repository;

    public AppController(DbContext context)
    {
        this.context = context;
        this.repository = new Repository<TEntity>(context);
    }

    public async Task<ICollection<System.Collections.Hashtable>> Get()
    {
        IEnumerable<TEntity?> Results = await repository.GetAll() ;
        if (Results.Count() == 0)
        {
            throw new ElementsNotFoundException("No elements found");
        }
        return Results.ToODto();
    }

    public async Task<System.Collections.Hashtable> Get(int id)
    {
        TEntity? Result = await repository.Get(id);
        if (Result == null)
        {
            throw new ElementsNotFoundException("Element not found");
        }
        return Result.ToODto();
    }

    public async Task<ODtoT> Post( IDtoT entity)
    {
        TEntity? InputObject = System.Activator.CreateInstance<TEntity>();
        // copy properties from entity to InputObject
        foreach (var property in entity.GetType().GetProperties())
        {
            property.SetValue(InputObject, property.GetValue(entity));
        }

        InputObject.OnBeforeAdd();

        TEntity? Result = await repository.Add(InputObject);

        if (Result == null)
        {
            throw new AddEntityFails("Element not found");
        }

        return Result.ToODto<ODtoT>();
        
    }


    public async Task<ODtoT> Patch(int id,  EZApi.Model.UpdateEntityModels contexts)
    {
        // Get the entity from the database
        TEntity? Result = await repository.Get(id);
        if (Result == null)
        {
            throw new ElementsNotFoundException("Element not found");
        }

        foreach (var context in contexts.datas)
        {
            // Get the property from the entity
            var property = Result.GetType().GetProperty(context.Attribute);
            if (property == null)
            {
                throw new PropertyNotFoundException("Property not found");
            }

            // Set the property value
            property.SetValue(Result, context.NewValue);
        }

        Result = await repository.Update(Result);

        if (Result == null)
        {
            throw new UpdateEntityFails("EntityFramework doesn't return the updated entity");
        }

        return Result.ToODto<ODtoT>();

    }

    public async Task<ODtoT> Delete(int id)
    {
        var Result = await repository.Delete(id);

        if (Result == null)
        {
            throw new DeleteEntityFails("EntityFramework doesn't return the deleted entity");
        }

        return Result.ToODto<ODtoT>();
    }


}