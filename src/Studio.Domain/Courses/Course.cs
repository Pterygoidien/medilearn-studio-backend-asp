using ErrorOr;

using Studio.Domain.Common;
using Studio.Domain.Sections;

namespace Studio.Domain.Courses;

public class Course : StudioEntity
{
    public string? Description { get; set; }
    public string Author { get; set; }
    public string? ImageUrl { get; set; }
    // private readonly List<Guid> _sectionIds = new();
    // private readonly List<Guid> _authorIds = new();

    public Course(string title, string author = "Admin") : base(title)
    {
        Author = author;
    }

    // public ErrorOr<Success> AddSection(Section section)
    // {
    //     // _sectionIds.Throw().IfContains(section.Id, "Section already exists in course");
    //     _sectionIds.Add(section.Id);

    //     return Result.Success;
    // }

    // public bool HasSection(Guid sectionId)
    // {
    //     return _sectionIds.Contains(sectionId);
    // }

    // public ErrorOr<Success> RemoveSection(Guid sectionId)
    // {
    //     _sectionIds.Remove(sectionId);
    //     return Result.Success;
    // }


}
