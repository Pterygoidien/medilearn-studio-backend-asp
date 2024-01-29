using ErrorOr;
using MediatR;
using Studio.Domain.Courses;

namespace Studio.Application.Courses.Commands.CreateCourse;

public record CreateCourseCommand(string Title) : IRequest<ErrorOr<Course>>;

