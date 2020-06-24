using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using clase_4.Models;

namespace clase_4.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly DataBaseContext _context;
    private IConfiguration _config { get; }

    public AuthController(DataBaseContext context, IConfiguration config)
    {
      _context = context;
      _config = config;
    }

    [HttpPost("register")]
    public async Task<ActionResult<Vehicle>> Register(User request){
      _context.Users.Add(request);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetVehicle", new { id = request.Id }, request);
    }

    [HttpPost("login")]
    public IActionResult Login(User request)
    {
      var user = this._context.Users.SingleOrDefault(x => x.Email == request.Email && x.Password == request.Password);
      if (user == null)
      {
          return Unauthorized("Invalid email or password");
      }
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings").GetSection("APP_KEY").Value);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      //var response = { token: tokenHandler.WriteToken(token)};
      return Ok(new { token = tokenHandler.WriteToken(token) });
    }
  }
}
