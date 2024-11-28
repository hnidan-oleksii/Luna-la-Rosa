using BLL.Services.Interfaces;
using BLL.DTO.User;
using DAL.Helpers.Params;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    //[Authorize(Roles = "admin")]
    [HttpGet]
    public async Task<IActionResult> GetAllUsers([FromQuery] UserParams userParams)
    {
        var users = await _userService.GetAllUserAsync(userParams);
        return Ok(users);
    }

    //[Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] CreateUserDto userDto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var userId = await _userService.AddUserAsync(userDto, cancellationToken);
        return CreatedAtAction(nameof(GetUserById), new { id = userId }, userDto);
    }

    //[Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto userDto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != userDto.Id)
            return BadRequest("User ID mismatch.");

        await _userService.UpdateUserAsync(userDto, cancellationToken);
        return NoContent();
    }

    //[Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id, CancellationToken cancellationToken)
    {
        await _userService.DeleteUserAsync(id, cancellationToken);
        return NoContent();
    }
}