using AuthenticationWitthJWT.Contexts;
using AuthenticationWitthJWT.DTOs;
using AuthenticationWitthJWT.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationWitthJWT.Services
{
    public class AuthServices(AuthContext _context, IConfiguration configutation) : IAuthServices
    {

        private readonly PasswordHasher<User> _passwordHasher = new();


        //public string GenerateJWTTokenString(LoginUser user)
        //{
        //    IEnumerable<Claim> claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Email, user.Username),
        //        new Claim(ClaimTypes.Role, "Admin")
        //    };

        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));

        //    SigningCredentials signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

        //    var securityToken = new JwtSecurityToken(
        //        claims: claims,
        //        expires: DateTime.Now.AddMinutes(30),
        //        signingCredentials: signingCred,
        //        issuer: _config.GetSection("Jwt:Issuer").Value,
        //        audience: _config.GetSection("Jwt:Audience").Value);



        //    string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
        //    return tokenString;
        //}
        public bool Login(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Username == user.Username);

            if (existingUser == null)
                return false;

            var result = _passwordHasher.VerifyHashedPassword(existingUser, existingUser.Password, user.Password);
            return result == PasswordVerificationResult.Success;
        }

        public User Register(User user)
        {
            if (_context.Users.Any(u => u.Username == user.Username))
            {
                throw new InvalidOperationException("User already exists.");
            }

            user.Password = _passwordHasher.HashPassword(user, user.Password);

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }
    }
}
