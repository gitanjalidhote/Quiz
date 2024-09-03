namespace ElearningQuizSystem.Api.DTOs
{
    public class RegisterUserDTO
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; } // "Student" or "Instructor"
    }
}
