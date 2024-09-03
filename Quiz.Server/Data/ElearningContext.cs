using Microsoft.EntityFrameworkCore;
using Quiz.Server.Models;

namespace ElearningQuizSystem.Api.Data
{
    public class ElearningContext : DbContext
    {
        public ElearningContext(DbContextOptions<ElearningContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<QuizResult> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<QuizResult> QuizResults { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurations and constraints
        }
    }
}
