using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quiz.API.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        [Column(TypeName ="nvarchar(250)")]
        public string QuestionBody { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        public string Answer1 { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        public string Answer2 { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        public string Answer3 { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        public string Answer4 { get; set; }
        public int CorrectAnswer1 { get; set; }
    }
}