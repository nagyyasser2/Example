using Example.Core.Configurations;
using Example.Core.Interfaces;
using Example.Core.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;

namespace Example.Core.Services
{
    public class UsersService(IUnitOfWork unitOfWork, IOptions<JwtOptions> jwtOptions)
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly JwtOptions _jwtOptions = jwtOptions.Value;

        public Author? FindAuthorByName(string name)
        {
            return _unitOfWork.Authors.Find(a => a.Name == name);
        }

        public string? Authenticate(string username, string password)
        {
            var author = FindAuthorByName(username);

            return author == null ? null :
                GenerateToken(author);
        }

        private string GenerateToken(Author author)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtOptions.SigningKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity([
                    new Claim(ClaimTypes.NameIdentifier, author.Id.ToString()),
                    new Claim(ClaimTypes.Name, author.Name),
                    new Claim(ClaimTypes.Role, "Admin"),
                ])      
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}