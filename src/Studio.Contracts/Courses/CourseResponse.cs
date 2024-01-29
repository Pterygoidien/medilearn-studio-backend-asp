namespace Studio.Contracts.Courses;

public record CourseResponse(string Id, string Title, DateTime CreatedAt, string? Description = null);
