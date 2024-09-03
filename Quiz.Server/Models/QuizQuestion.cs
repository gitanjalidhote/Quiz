using System;
using System.Collections.Generic;

namespace Quiz.Server.Models;

public partial class QuizQuestion
{
    public int QuizId { get; set; }

    public int QuestionId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Question Question { get; set; } = null!;

    public virtual Quiz Quiz { get; set; } = null!;
}
