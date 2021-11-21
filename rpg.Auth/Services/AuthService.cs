using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using rpg.Auth.Models.Request;
using rpg.Auth.Models.Response;
using rpg.DAO;
using rpg.DAO.Models.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Auth.Services
{
    public interface IAuthService
    {
        public Task<LoginResponse> Login(LoginRequest request);
        //public IActionResult Register();

    }
    public class AuthService : IAuthService
    {
        private RpgContext _rpgContext { get; set; }

        public AuthService(RpgContext rpgContext)
        {
            _rpgContext = rpgContext;
        }
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            if (request == null)
            {
                return null;
            }

            //todo: hash password
            var dbUser = await _rpgContext.Users
                .Where(_ => _.Email.Equals(request.Email) && _.Password.Equals(request.Password))
                .FirstOrDefaultAsync();
            if (dbUser != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperDuperSecretKey"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signinCredentials
                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return new LoginResponse { Token = tokenString };
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Register(SignupRequest request)
        {   
            if(request == null) return false;
            var toDb = new User
            {
                Email = request.Email,
                Password = request.Password
            };

            return false;
        }
    }
}
