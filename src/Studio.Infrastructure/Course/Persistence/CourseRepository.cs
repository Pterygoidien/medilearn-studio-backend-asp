using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Studio.Application.Common.Interfaces;
using Studio.Domain.Courses;
using Studio.Infrastructure.Common.Persistence;

namespace Studio.Infrastructure.Courses.Persistence;

public class CourseRepository : ICourseRepository
{


    private readonly StudioDbContext _dbContext;
    public CourseRepository(StudioDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task CreateCourseAsync(Course course)
    {
        await _dbContext.Courses.AddAsync(course);
    }

    public async Task<Course?> GetCourseByIdAsync(Guid id)
    {
        return await _dbContext.Courses.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Course?> GetCourseByNameAsync(string title)
    {
        return await _dbContext.Courses.FirstOrDefaultAsync(c => c.Title == title);
    }

    public async Task<List<Course>> GetCoursesAsync()
    {
        return await _dbContext.Courses.ToListAsync();
    }

}
