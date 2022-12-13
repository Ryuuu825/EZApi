namespace EZApi.API.Controller;

using Microsoft.AspNetCore.Mvc;

public interface IAPIController<T, IDtoT , ODtoT>
    where T : class 
    where IDtoT : class // Input DTO
    where ODtoT : class // Output DTO
{
    public Task<IActionResult> Get();
    public Task<IActionResult> Get(int id);
    public Task<IActionResult> Patch(int id, [FromBody] EZApi.Model.UpdateEntityModels entity);
    public Task<IActionResult> Delete(int id);


}
