using AutoMapper;
using CulinaryNotes.BL.Features.Auth;
using CulinaryNotes.BL.Features.Auth.Entities;
using CulinaryNotes.Controllers.Entities;
using CulinaryNotes.Controllers.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryNotes.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IAuthProvider _authorizationProvider, IMapper _mapper)
    : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
    {
        var registerModel = _mapper.Map<RegisterUserModel>(request);
        var userModel = await _authorizationProvider.RegisterUserAsync(registerModel);
        return Ok(_mapper.Map<UserResponse>(userModel));
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginUser([FromBody] AuthorizeUserRequest request)
    {
        var authorizeModel = _mapper.Map<AuthorizeUserModel>(request);
        var tokens = await _authorizationProvider.AuthorizeUserAsync(authorizeModel);
        return Ok(tokens);
    }

    [HttpPost]
    [Route("refresh")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        var refreshToken = await _authorizationProvider.RefreshTokenAsync(request.RefreshToken);
        return Ok(refreshToken);
    }
}