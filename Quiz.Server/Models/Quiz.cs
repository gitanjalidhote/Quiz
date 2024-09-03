using System;
using System.Collections.Generic;

namespace Quiz.Server.Models;

public partial class Quiz
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int Duration { get; set; }

    public int InstructorId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User Instructor { get; set; } = null!;

    public virtual ICollection<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();

    public virtual ICollection<QuizResult> QuizResults { get; set; } = new List<QuizResult>();
}
