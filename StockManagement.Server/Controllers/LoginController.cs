﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Server.Entities;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly IConfiguration configuration;

    public LoginController(SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
    {
        this.signInManager = signInManager;
        this.configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid model");
        }

        var result = await signInManager.PasswordSignInAsync(model.username, model.password, false, false);

        if (result.Succeeded)
        {
             Console.WriteLine(model.username + " " + model.password);
            if (string.IsNullOrEmpty(model.username))
            {
                throw new ArgumentException("Username cannot be null or empty", nameof(model.username));
            }

            var token = GenerateJwtToken(model.username); // Assuming Username is unique
            return Ok(new {token});
        }
        else
        {
            return BadRequest("Invalid login attempt");
        }
    }

    private string GenerateJwtToken(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentException("Username cannot be null or empty", nameof(username));
        }

        var jwtKey = configuration["JwtKey"];
        if (string.IsNullOrEmpty(jwtKey))
        {
            throw new InvalidOperationException("JWT key is not configured properly.");
        }

        var issuer = configuration["JwtIssuer"];
        if (string.IsNullOrEmpty(issuer))
        {
            throw new InvalidOperationException("JWT issuer is not configured properly.");
        }

        var audience = configuration["JwtAudience"];
        if (string.IsNullOrEmpty(audience))
        {
            throw new InvalidOperationException("JWT audience is not configured properly.");
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            },
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public class LoginModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    // LoginModel and other actions...
}
