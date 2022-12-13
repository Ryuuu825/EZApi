# EZApi

```txt
A simple REST API framework for asp.net core
```

## What is EZApi?

EZApi is a simple REST API framework for asp.net core. It is designed to create a RESTFul API with defining data models only.

This project is inspired by my previous [project](https://github.com/Ryuuu825/ITP4915M-2022). I would like to extract the work done in that project and make it a standalone framework.

## How to use?

- define your data model

```csharp
public class Users : EZApi.Entity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}
```

- define your DTO model (optional)

```csharp
public class UsersInDto // for retrieving data from client side
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class UsersOutDto // for sending data to client side
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}
```

- Then, you can create a controller

  - with just model definition

    ```csharp
    [Route("v1/api/[controller]")] // optional, default is "api/[controller]s"
    public class UsersController : EntityControllerBase
        <Users, Users, Users>
    {
        public UsersController(DbContext context) : base(context)
        {
        }
        
    }
    ```

  - with model definition and DTO definition

```csharp
    [Route("v1/api/[controller]")] // optional, default is "api/[controller]s"
    public class UsersController : EntityControllerBase
        <Users, UsersInDto, UsersOutDto>
    {
        public UsersController(DbContext context) : base(context)
        {
        }
        
    }
```


## TODO

- Generate asp.net webapi from json files
