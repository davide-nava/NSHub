using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SalarySwissdecLogDialogMsg : BaseEntity
{
    public Guid RecipientId { get; set; }


    public DateTime CreationDate { get; set; }

    public string StoryId { get; set; } = null!;

    public string PrevRequestStoryId { get; set; } = null!;

    public string PrevResponseStoryId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string GetDialogContent { get; set; } = null!;

    public string ReplyDialogContent { get; set; } = null!;

    public bool IsRead { get; set; }

    public bool IsAnswerRequested { get; set; }

    public bool IsCompleted { get; set; }

    public string ResponseStoryId { get; set; } = null!;

    public virtual SalarySwissdecLogRecipient? SalarySwissdecLogRecipient { get; set; }
}
