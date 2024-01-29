using ErrorOr;
using Studio.Domain.Courses;

namespace Studio.Application.Common.Interfaces;

public interface ICourseRepository
{
    Task CreateCourseAsync(Course course);
    Task<Course?> GetCourseByIdAsync(Guid id);
    Task<Course?> GetCourseByNameAsync(string name);
    Task<List<Course>> GetCoursesAsync();
}