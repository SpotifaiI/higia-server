using HigiaServer.Application.DTOs;
using HigiaServer.Application.Services;
using HigiaServer.Domain.Common;
using HigiaServer.Infra.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HigiaServer.API.Controllers;

public class AuthenticationController : ControllerBase
{
    private readonly AuthenticationService _authenticationService;
    private readonly ApplicationDbContext _context;

    public AuthenticationController(AuthenticationService authenticationService, ApplicationDbContext context)
    {
        _authenticationService = authenticationService;
        _context = context;
    }

    [HttpPost("authentication")]
    public async Task<IActionResult> Authentication(AuthenticationDTO authenticateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
        }

        try
        {
            BaseUserEntity? user = await _context.Users.FirstOrDefaultAsync(u => u.Email == authenticateDTO.Email)
                .ConfigureAwait(false);
            if (user == null)
            {
                return NotFound("User not found");
            }

            if (BCrypt.Net.BCrypt.Verify(authenticateDTO.Password, user!.PasswordHash))
            {
                string token = _authenticationService.GenerateToken(user);
                return Ok(token);
            }

            return BadRequest("Invalid credentials");
        }
        catch (Exception error)
        {
            return BadRequest(error);
        }
    }
}