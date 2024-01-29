namespace Studio.Domain.Common;
public class StudioEntity : Entity
{

    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public StudioEntity(string title, Guid? id = null) : base(id ?? Guid.NewGuid())
    {
        Title = title;
        CreatedAt = DateTime.UtcNow;
    }

}
