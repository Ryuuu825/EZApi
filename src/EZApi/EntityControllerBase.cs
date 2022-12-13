namespace EZApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using EZApi.App.Controller;

[Route("api/[controller]")] // api/entity
public class EntityControllerBase<T, IDtoT, ODtoT> : ControllerBase , EZApi.API.Controller.IAPIController<T, IDtoT, ODtoT>  
    where T : Entity, new() // Entity
    where IDtoT : class // Input DTO
    where ODtoT : class // Output DTO
{
    protected readonly DbContext context;
    protected readonly AppController<T, IDtoT, ODtoT> appController;
    public EntityControllerBase(DbContext context)
    {
        this.context = context;
        this.appController = new AppController<T, IDtoT, ODtoT>(context);
    }
    public async Task<IActionResult> Get()
    {
        try {
            return Ok(await appController.Get());
        } catch (EZApi.Exceptions.ElementsNotFoundException e) {
            return NotFound(e.Message);
        }
    }
    public async Task<IActionResult> Get(int id)
    {
        try {
            return Ok(await appController.Get(id));
        } catch (EZApi.Exceptions.ElementsNotFoundException e) {
            return NotFound(e.Message);
        }
    }
    public async Task<IActionResult> Post([FromBody] IDtoT entity)
    {
        try {
            return Ok(await appController.Post(entity));
        } catch (EZApi.Exceptions.AddEntityFails e) {
            return BadRequest(e.Message);
        }
    }
    
    public async Task<IActionResult> Patch(int id, [FromBody] EZApi.Model.UpdateEntityModels entity)
    {
        try {
            return Ok(await appController.Patch(id, entity));
        } catch (EZApi.Exceptions.ElementsNotFoundException e) {
            return NotFound(e.Message);
        } catch (EZApi.Exceptions.UpdateEntityFails e) {
            return BadRequest(e.Message);
        }
    }
    public async Task<IActionResult> Delete(int id)
    {
        try {
            return Ok(await appController.Delete(id));
        } catch (EZApi.Exceptions.ElementsNotFoundException e) {
            return NotFound(e.Message);
        } catch (EZApi.Exceptions.DeleteEntityFails e) {
            return BadRequest(e.Message);
        }
    }

}
