using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using rpg.Auth.Models.Request;
using rpg.Auth.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Auth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPatch("Img/{id}")]
        public async Task<IActionResult> SetUrl(Guid id)
        {
            if (id == null) return BadRequest();
            var result = await _authService.SetUrl(id);
            if (result == null) return BadRequest();
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _authService.Login(request);
            if(result != null)
            {
                return Ok(result);
            } else
            {
                return UnprocessableEntity(request);
            }
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Register(SignupRequest request)
        {
            var result = await _authService.Register(request);
            if(result)
            {
                return Ok();
            } else
            {
                return UnprocessableEntity(request);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _authService.Get(id);
            if(result != null)
            {
                return Ok(result);
            } else
            {
                return NotFound(id);
            }
        }
    }
}
