using Microsoft.EntityFrameworkCore;
using quiz.API.Controllers;
using quiz.API.Models;

public static class SeedData
{
  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var context = new MusicQuizDbContext(
        serviceProvider.GetRequiredService<
            DbContextOptions<MusicQuizDbContext>>()))
    {
      // Look for any movies.
      if (context.Questions.Any())
      {
        return;   // DB has been seeded
      }

      context.Questions.AddRange(
          new Question
          {
            QuestionBody = "Who was the lead guitarist in the band Buffalo Springfield?",

            Answer1 = "Steven Stills",
            Answer2 = "Neil Young",
            Answer3 = "George Harrison",
            Answer4 = "Jimmy Page",
            CorrectAnswer1 = 2
          },

          new Question
          {
            QuestionBody = "Who famously left the Beatles before the become succesful?",

            Answer1 = "Paul Simon",
            Answer2 = "John Paul Jones",
            Answer3 = "Stuart Sutcliffe",
            Answer4 = "Keith Richards",
            CorrectAnswer1 = 3
          },

          new Question
          {
            QuestionBody = "Which Pink Floyd album featured the song 'Money'?",

            Answer1 = "Dark Side of the Moon",
            Answer2 = "Wish You Were Here",
            Answer3 = "Animals",
            Answer4 = "The Wall",
            CorrectAnswer1 = 1
          },

          new Question
          {
            QuestionBody = "Who was the drummer in the band Fleetwood Mac?",

            Answer1 = "John McVie",
            Answer2 = "Lindsay Buckingham",
            Answer3 = "John Bonham",
            Answer4 = "Mick Fleetwood",
            CorrectAnswer1 = 4
          },

          new Question
          {
            QuestionBody = "Which famous musician's real name is Reginald Dwight?",

            Answer1 = "Slash",
            Answer2 = "Elton John",
            Answer3 = "Prince",
            Answer4 = "Billy Joel",
            CorrectAnswer1 = 2
          }

      );
      context.SaveChanges();
    }
  }
}