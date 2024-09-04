using Microsoft.AspNetCore.Mvc;

namespace Quiz.Server.DTOs
{
    public class RegisterUserDTO
    {
    //public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerUserDto);


        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; } // "Student" or "Instructor"
    }
}
