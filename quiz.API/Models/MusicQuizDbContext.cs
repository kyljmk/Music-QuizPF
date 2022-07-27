using Microsoft.EntityFrameworkCore;

namespace quiz.API.Models
{
    public class MusicQuizDbContext : DbContext
    {
        public MusicQuizDbContext(DbContextOptions<MusicQuizDbContext> options) : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<QuizTaker> QuizTakers { get; set; }
    }
}