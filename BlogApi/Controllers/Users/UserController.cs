
using BlogApi.Controllers.Comments.Response;
using BlogApi.Controllers.Users.Requests;
using BlogApi.Controllers.Users.Response;
using BlogApi.Functions.Record;
using BlogApi.Functions.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers.Users;

[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IConfiguration _configuration;

    private readonly IUserFunction _userFunction;
    public UserController(IConfiguration configuration, IUserFunction userFunction)
    {
        _configuration = configuration;
        _userFunction = userFunction;
    }
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {

        var response = new UsersResponse
        {
            Users = await _userFunction.GetUsers()
        };
        return Ok(response);
    }
    [Authorize]
    [HttpGet("One")]
    public async Task<IActionResult> GetUser(int id)
    {
        var response = await _userFunction.GetUser(id);

        return Ok(response);
    }
    [Authorize]
    [HttpDelete]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var response = await _userFunction.DeleteUser(id);
        return Ok(response);
    }
    [Authorize]
    [HttpPut("ChangeRole")]
    public async Task<IActionResult> PutUserRole([FromBody] ChangeRoleUserRequest request)
    {
        var response = await _userFunction.ChangeUserRole(request.Id, request.Role);
        return Ok(response);
    }

}
