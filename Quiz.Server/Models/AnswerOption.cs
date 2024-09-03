using System;
using System.Collections.Generic;

namespace Quiz.Server.Models;

public partial class AnswerOption
{
    public int Id { get; set; }

    public int QuestionId { get; set; }

    public string OptionText { get; set; } = null!;

    public bool IsCorrect { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Question Question { get; set; } = null!;
}
