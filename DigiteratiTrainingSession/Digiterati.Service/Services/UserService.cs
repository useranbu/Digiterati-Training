using Core.ViewModel;
using Digiterati.Core.Abstractions;
using Digiterati.Data;
using Digiterati.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
            throw new NotImplementedException();
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
    }
}
