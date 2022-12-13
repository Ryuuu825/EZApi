namespace base_usage.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using EZApi;

using base_usage.Models;


public class UsersController : EntityControllerBase
    <Users, Users, Users>
{
    public UsersController(DbContext context) : base(context)
    {
    }
    
}