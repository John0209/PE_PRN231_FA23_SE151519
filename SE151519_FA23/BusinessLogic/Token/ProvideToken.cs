using Entities.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Token
{
    public class ProvideToken
    {
        private readonly IConfiguration _configuration;
        private static ProvideToken _instance;
        public static ProvideToken Instance => _instance;
        private ProvideToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static void Initialize(IConfiguration configuration)
        {
            if (_instance == null)
                _instance = new ProvideToken(configuration);
        }

        public virtual string GenerateToken(UserRole user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = _configuration["AppSettings:SecretKey"];
            if (secretKey == null)
            {
                return "Not Found SecretKey";
            }
            var key = Encoding.ASCII.GetBytes(secretKey);
            // Tiếp tục với việc tạo token bằng key
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            // Thêm các claim cần thiết vào đây (ví dụ: UserId)
            new Claim("Id", user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.UserRole1.ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(10), // Thời gian hiệu lực của token (vd: 30 phút)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
