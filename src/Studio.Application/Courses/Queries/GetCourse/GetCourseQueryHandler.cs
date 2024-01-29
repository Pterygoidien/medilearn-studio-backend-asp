using ErrorOr;
using MediatR;
using Studio.Application.Common.Interfaces;
using Studio.Domain.Courses;

namespace Studio.Application.Courses.Queries.GetCourse;

public class GetCourseQueryHandler : IRequestHandler<GetCourseQuery, ErrorOr<Course>>
{
    private readonly ICourseRepository _courseRepository;

    public GetCourseQueryHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<ErrorOr<Course>> Handle(GetCourseQuery request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetCourseByIdAsync(request.Id);
        if (course is null)
            return Error.NotFound("Course not found");


        return course;
    }
}