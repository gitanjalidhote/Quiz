namespace Quiz.Server.DTOs
{
    public class FeedbackDTO
    {
        public int QuizResultId { get; set; }
        public required string Content { get; set; }
    }
}
