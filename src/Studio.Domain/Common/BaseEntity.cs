namespace Studio.Domain.Common;
public class BaseEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public BaseEntity(string title)
    {
        Id = Guid.NewGuid();
        Title = title;
        CreatedAt = DateTime.UtcNow;
    }

}
