using ElearningQuizSystem.Api.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Quiz.Server.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ElearningQuizSystem.Api.Services
{
    public class AuthenticationService
    {
        private readonly QuizContext _context;
        private readonly IConfiguration _configuration;

        // Constructor with dependency injection
        public AuthenticationService(QuizContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // Method to register a new user
        public async Task<(bool Success, string Token, string[] Errors)> RegisterUserAsync(RegisterUserDTO registerUserDto)
        {
            // Check if the user already exists
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == registerUserDto.Email);

            if (existingUser != null)
            {
                return (false, null, new[] { "User already exists." });
            }

            // Hash the password
            var hashedPassword = HashPassword(registerUserDto.Password);

            // Create new user
            var user = new User
            {
                Email = registerUserDto.Email,
                Password = hashedPassword,
                // Add other fields as necessary
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return (true, null, null);
        }

        // Method to log in a user and generate a JWT token
        public async Task<(bool Success, string Token, string[] Errors)> LoginUserAsync(LoginUserDTO loginUserDto)
        {
            // Retrieve user from the database
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == loginUserDto.Email);

            if (user == null || !VerifyPassword(loginUserDto.Password, user.Password))
            {
                return (false, null, new[] { "Invalid credentials." });
            }

            // Generate JWT token
            var token = GenerateJwtToken(user);

            return (true, token, null);
        }

        // Helper method to hash the password
        private string HashPassword(string password)
        {
            using (var hmac = new HMACSHA256())
            {
                var hashedBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        // Helper method to verify the password
        private bool VerifyPassword(string enteredPassword, string storedPasswordHash)
        {
            var hashedPassword = HashPassword(enteredPassword);
            return hashedPassword == storedPasswordHash;
        }

        // Helper method to generate a JWT token
        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    // Add other claims if needed
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
