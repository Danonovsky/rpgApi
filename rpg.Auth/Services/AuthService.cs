using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using rpg.Auth.Models.Request;
using rpg.Auth.Models.Response;
using rpg.Common.Models.Response;
using rpg.Common.Services;
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
        public Task<bool> Register(SignupRequest request);
        public Task<PublicUserResponse> Get(Guid id);
        public Task<SetUrlResponse> SetUrl(Guid id);

    }
    public class AuthService : IAuthService
    {
        private RpgContext _rpgContext { get; set; }
        private IConfiguration _configuration { get; set; }
        private IFileService _fileService { get; set; }

        public AuthService(
            RpgContext rpgContext,
            IConfiguration configuration,
            IFileService fileService
            )
        {
            _rpgContext = rpgContext;
            _configuration = configuration;
            _fileService = fileService;
        }

        public async Task<SetUrlResponse> SetUrl(Guid id)
        {
            var item = await _rpgContext.Users
                .Where(_ => _.Id == id)
                .FirstOrDefaultAsync();
            if (item == null) return null;

            var url = await _fileService.Upload();
            if (url == null) return null;

            item.Url = url;
            _rpgContext.Update(item);
            int result = await _rpgContext.SaveChangesAsync();

            if (result == 0) return null;
            return new SetUrlResponse
            {
                Url = url
            };
        }

        public async Task<PublicUserResponse> Get(Guid id)
        {
            if (id == null) return null;
            var item = await _rpgContext.Users
                .Where(_ => _.Id == id)
                .Select(_ => new PublicUserResponse(_))
                .FirstOrDefaultAsync();
            if(item == null) return null;
            return item;
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
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                            _configuration.GetSection("AppSettings").GetValue<string>("Secret")
                            ));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>()
                {
                    new Claim("id", dbUser.Id.ToString()),
                    new Claim("name", dbUser.Name)
                };

                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: claims,
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
            if (!request.ComparePasswords()) return false;
            var exists = _rpgContext.Users.Where(_ => _.Email == request.Email).Any();
            if (exists) return false;

            var toDb = new User
            {
                Email = request.Email,
                Password = request.Password,
                Name = request.Name
            };
            await _rpgContext.Users.AddAsync(toDb);
            await _rpgContext.SaveChangesAsync();

            return true;
        }
    }
}
