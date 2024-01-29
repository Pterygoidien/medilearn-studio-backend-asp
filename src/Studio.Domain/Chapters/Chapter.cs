using Studio.Domain.Common;

namespace Studio.Domain.Chapters;

public class Chapter : BaseEntity
{
    public string? Description { get; set; }
    public Chapter(string title) : base(title)
    {
    }

}