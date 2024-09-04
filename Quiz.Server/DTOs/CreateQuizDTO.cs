using System.Collections.Generic;

namespace Quiz.Server.DTOs
{
    public class CreateQuizDTO
    {
        internal int Id;

        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; } // Duration in minutes
        public List<int> QuestionIds { get; set; } // IDs of selected questions
    }
}
