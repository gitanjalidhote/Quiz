using System;
using System.Collections.Generic;

namespace Quiz.Server.Models;

public partial class Feedback
{
    public int Id { get; set; }

    public int QuizResultId { get; set; }

    public int InstructorId { get; set; }

    public string? FeedbackText { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User Instructor { get; set; } = null!;

    public virtual QuizResult QuizResult { get; set; } = null!;
    public int Rating { get; internal set; }
    public string Comments { get; internal set; }
}
