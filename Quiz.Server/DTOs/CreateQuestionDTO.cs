using System.Collections.Generic;

namespace ElearningQuizSystem.Api.DTOs
{
    public class CreateQuestionDTO
    {
        public string Content { get; set; }
        public string Type { get; set; } // "MultipleChoice", "TrueFalse", "ShortAnswer"
        public string Subject { get; set; }
        public List<AnswerOptionDTO> AnswerOptions { get; set; }
    }

    public class AnswerOptionDTO
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
