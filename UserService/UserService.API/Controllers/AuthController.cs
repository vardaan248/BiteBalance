using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Interfaces;

namespace UserService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(string username, string email, string password)
    {
        var result = await _authService.RegisterAsync(username, email, password);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var result = await _authService.LoginAsync(email, password);
        return Ok(result);
    }

    [HttpGet("checkauth")]
    [Authorize]
    public string CheckAuth()
    {
        return "It is working!";
    }
}
