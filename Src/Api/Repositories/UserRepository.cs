using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using Kosku.Data.Entities;
using Kosku.Data.Model;
using System.Linq;
using System.Text;
using Kosku.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;

namespace Kosku.Repositories
{
    public interface IUserRepository
    {
        UserResponse authenticate(UserRequest request);
        IEnumerable<User> getAll();

        User GetById(int id);
    }

    public class UserRepository : IUserRepository
    {
        UserContext _context;
        AppSettings _appSettings;
        public UserRepository(UserContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public UserResponse authenticate(UserRequest request)
        {
            var response = from u in _context.User
                           where u.username == request.username
                           select u;

            var user = response.First();

            if (user == null) return null;

            var token = generateJwtToken(user);

            return new UserResponse(user, token);
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                    )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public IEnumerable<User> getAll()
        {
            return _context.User;
        }

        public User GetById(int id)
        {
            return _context.User.Find(id);            
        }
    }
}