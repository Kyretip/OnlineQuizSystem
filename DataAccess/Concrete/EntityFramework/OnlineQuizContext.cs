using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class OnlineQuizContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;User Id=postgres;Password=root;Database=QuizDb;"); 
        }

        public DbSet <Answer> Answers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonUser> LessonUsers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizUser> QuizUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
    }
}
