using Microsoft.AspNetCore.Mvc;
using UserApp.Api.Models;
using UserApp.Api.Services;

namespace UserApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly UsersService _usersService;
    public UsersController(UsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _usersService.GetUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(long id)
    {
        try
        {
            var user = _usersService.GetUserById(id);
            return Ok(user);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult AddUser([FromBody] User user)
    {
        try
        {
            var saved = _usersService.AddUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = saved.Id }, saved);
        }
        catch (ArgumentException)
        {
            return BadRequest("Name cannot be empty");
        }
    }
}