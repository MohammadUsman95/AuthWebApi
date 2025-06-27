using AuthWebApi.Entities;
using AuthWebApi.Model;
using AuthWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuthWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService service;
        public AuthController(IAuthService service)
        {
            this.service = service;
        }


        [HttpPost("register")]
        public async Task<ActionResult<User?>> Register(UserDto request)
        {
            var user = await service.RegisterAsync(request);
            if (user is null)
                return BadRequest("Username already exists!");
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken(UserDto request)
        {
            var token = await service.LoginAsync(request);
            if (token is null)
                return BadRequest("Username/password is wrong");
            return Ok(token);
        }

        // Post Endpoint for refresh token.
        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto request)   // user id  and refresh token come for this request we will create one more dto in token response dto. 
        {
            var token = await service.RefreshTokenAsync(request);
            if (token is null)
                return BadRequest("Invalid/expired token");
            return Ok(token);
        }

        // Creating end point for authorize user can have access to this end point.
        [HttpGet("Auth-endpoint")]
        [Authorize] // authorize attribute is used to protect the endpoint.
        public ActionResult AuthCheck()
        {
            return Ok(); // if user is authorized then this message will be returned. (Setup on Program.cs file)
        }

        // role based authorization.
        [HttpGet("Admin-endpoint")]
        [Authorize(Roles = "Admin")] // we can use , and seprated list roles this endpoint have access, now we can allow only Admin.  ex [Authorize(Roles ="Admin,Manager, so on.")].
        public ActionResult AdminCheck()
        {
            return Ok();

        }
        // now difining roles User class,
    }
}