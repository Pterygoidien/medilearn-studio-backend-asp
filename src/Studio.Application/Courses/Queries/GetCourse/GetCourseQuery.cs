using ErrorOr;
using MediatR;
using Studio.Domain.Courses;

namespace Studio.Application.Courses.Queries.GetCourse;

public record GetCourseQuery(Guid Id) : IRequest<ErrorOr<Course>>;