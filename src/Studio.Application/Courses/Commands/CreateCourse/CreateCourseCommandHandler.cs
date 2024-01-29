using ErrorOr;
using MediatR;
using Studio.Application.Common.Interfaces;
using Studio.Domain.Courses;

namespace Studio.Application.Courses.Commands.CreateCourse;

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, ErrorOr<Course>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICourseRepository _courseRepository;

    public CreateCourseCommandHandler(IUnitOfWork unitOfWork, ICourseRepository courseRepository)
    {
        _unitOfWork = unitOfWork;
        _courseRepository = courseRepository;
    }

    public async Task<ErrorOr<Course>> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
    {
        Course course = new Course(
            title: command.Title,
            author: "admin-from-applicationLayer");
        await _courseRepository.CreateCourseAsync(course);
        await _unitOfWork.CommitChangesAsync();
        return course;

    }
}
