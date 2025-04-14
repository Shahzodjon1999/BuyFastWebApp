using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BuyFastApi.Authentications;
using BuyFastApi.Infrastructure;
using BuyFastApi.Models;
using BuyFastDTO.ResponseModel;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _config;

    public AuthController(AppDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest model)
    {
        if (await _context.Users.AnyAsync(u => u.Email == model.Email))
            return BadRequest("User already exists");

        var user = new User
        {
            Email = model.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
            Role = "User"
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok("User registered");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest model)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            return Unauthorized("Invalid credentials");

        var token = GenerateJwtToken(user);
        return Ok(new { token });
    }
    
    private AuthResponse GenerateJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name,user.Username),
            new Claim("Id",user.Id.ToString()),
            new Claim(ClaimTypes.Role,user.PasswordHash),
        };

        var jwt = new JwtSecurityToken(
            issuer:AuthOptions.Issuer,
            audience:AuthOptions.Audience,
            claims:claims,
            expires:DateTime.Now.Add(TimeSpan.FromMinutes(AuthOptions.lifeTime)),
            signingCredentials:new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),SecurityAlgorithms.HmacSha256));
   
        string tokenString = new JwtSecurityTokenHandler().WriteToken(jwt);
        var authResponse = new AuthResponse
        {
            Token = tokenString,
            Role = user.Role,
        };
        return authResponse;
    }
}