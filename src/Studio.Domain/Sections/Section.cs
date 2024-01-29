using ErrorOr;
using Studio.Domain.Chapters;
using Studio.Domain.Common;

namespace Studio.Domain.Sections;

public class Section : BaseEntity
{
    public string? Description { get; set; }
    private readonly List<Guid> _chapterIds = new();
    public Section(string title) : base(title)
    {
    }

    public ErrorOr<Success> AddChapter(Chapter chapter)
    {
        _chapterIds.Add(chapter.Id);
        return Result.Success;
    }
    public bool HasChapter(Guid chapterId)
    {
        return _chapterIds.Contains(chapterId);
    }

    public ErrorOr<Success> RemoveChapter(Guid chapterId)
    {
        _chapterIds.Remove(chapterId);
        return Result.Success;
    }

}
