using ErrorOr;
using MediatR;
using Studio.Domain.Courses;

namespace Studio.Application.Courses.Queries.ListCourses;

public record ListCoursesQuery : IRequest<ErrorOr<List<Course>>>;
