using Core.ViewModel;
using Digiterati.Core.Abstractions;
using Digiterati.Data;
using Digiterati.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Digiterati.Service.Services
{
    public class UserService : IUserService
    {
        private readonly EmployeeDbContext _dbContext;

        public UserService(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.UserName == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public async Task<Users?> CreateUser(UserDto User)
        {
            var result = new Users();
            if (User != null)
            {
                result.UserName = User.UserName;
                result.Password = User.Password;
                result.Email = User.Email;
                result.Name = User.Name;
                result.Role = User.Role;
                await _dbContext.Users.AddAsync(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return result;
        }

        public IEnumerable<Users> GetAll()
        {
            throw new NotImplementedException();
        }

        public Users GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Users?> GetUser(string UserName)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(s => s.UserName == UserName);
            return result ?? null;
        }

        private string generateJwtToken(Users user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("This is my first Security key and hope this is enough to create jwt token");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
