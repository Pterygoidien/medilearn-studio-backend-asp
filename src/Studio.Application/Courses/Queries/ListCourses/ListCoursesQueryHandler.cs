using ErrorOr;
using MediatR;
using Studio.Application.Common.Interfaces;
using Studio.Domain.Courses;

namespace Studio.Application.Courses.Queries.ListCourses;

public class ListCoursesQueryHandler : IRequestHandler<ListCoursesQuery, ErrorOr<List<Course>>>
{
    private readonly ICourseRepository _courseRepository;

    public ListCoursesQueryHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<ErrorOr<List<Course>>> Handle(ListCoursesQuery request, CancellationToken cancellationToken)
    {
        var courses = await _courseRepository.GetCoursesAsync();
        return courses;
    }
}
