using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.DTOs;
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
    public async Task<IActionResult> Register([FromBody]RegisterDto registerationDetails)
    {
        var result = await _authService.RegisterAsync(registerationDetails.Username, registerationDetails.Email, registerationDetails.Password);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]UserLogin userLogin)
    {
        var result = await _authService.LoginAsync(userLogin.Email, userLogin.Password);
        return Ok(result);
    }

    [HttpGet("checkauth")]
    [Authorize]
    public string CheckAuth()
    {
        return "It is working!";
    }
}
