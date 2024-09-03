using System.Collections.Generic;

namespace ElearningQuizSystem.Api.DTOs
{
    public class SubmitQuizDTO
    {
        public int QuizId { get; set; }
        public int StudentId { get; set; }
        public Dictionary<int, string> Answers { get; set; } // Key: QuestionId, Value: Answer
    }
}
