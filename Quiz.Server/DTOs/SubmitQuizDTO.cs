using System.Collections.Generic;

namespace Quiz.Server.DTOs
{
    public class SubmitQuizDTO
    {
        public int QuizId { get; set; }
        public int StudentId { get; set; }
        public required Dictionary<int, string> Answers { get; set; } // Key: QuestionId, Value: Answer
    }
}
