using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.DTO_s;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
        }

        // POST: Api/Account/Login
        [HttpPost("Login")]
        public async Task<ActionResult<string>> CreateToken(LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (result.Succeeded)
                {
                    string token = await GetTokenAsync(user);
                    return Created("", token); //returns only the token                    
                }
            }
            return BadRequest();
        }

        // POST: Api/Account/Register
        [HttpPost("Register")]
        public async Task<ActionResult<string>> Register(RegisterDTO model)
        {
            IdentityUser user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                //await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "gebruiker"));
                string token = await GetTokenAsync(user);
                return Created("", token);
            }
            return BadRequest();
        }

        private async Task<string> GetTokenAsync(IdentityUser user)
        {
            // Create the token
            var claims = new List<Claim>()
            {
              new Claim(JwtRegisteredClaimNames.Sub, user.Email),
              new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var roleClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(roleClaims);
            var token = new JwtSecurityToken(
              null, null,
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}