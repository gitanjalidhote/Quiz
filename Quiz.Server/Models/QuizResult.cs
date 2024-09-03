using System;
using System.Collections.Generic;

namespace Quiz.Server.Models;

public partial class QuizResult
{
    public int Id { get; set; }

    public int QuizId { get; set; }

    public int StudentId { get; set; }

    public int Score { get; set; }

    public DateTime? CompletedAt { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual Quiz Quiz { get; set; } = null!;

    public virtual User Student { get; set; } = null!;
}
