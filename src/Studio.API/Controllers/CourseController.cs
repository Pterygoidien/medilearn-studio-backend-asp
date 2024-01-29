using MediatR;
using Microsoft.AspNetCore.Mvc;
using Studio.Application.Courses.Commands.CreateCourse;
using Studio.Application.Courses.Queries.GetCourse;
using Studio.Application.Courses.Queries.ListCourses;
using Studio.Contracts.Courses;

namespace GymManagement.Api.Controllers;
[Route("api/[controller]")]
public class CourseController : ApiController
{
    private readonly ISender _mediator;
    public CourseController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourse(CreateCourseRequest request)
    {
        var command = new CreateCourseCommand(
            request.Title
        );
        var createCourseResult = await _mediator.Send(command);

        return createCourseResult.Match(
            course => CreatedAtAction(
                nameof(GetCourse),
                new { courseId = course.Id },
                new CourseResponse(course.Id.ToString(), course.Title)
            ),
            Problem);
    }


    [HttpGet("{courseId:guid}")]
    public async Task<IActionResult> GetCourse(
        Guid courseId
    )
    {
        var query = new GetCourseQuery(courseId);
        var getCourseResult = await _mediator.Send(query);
        return getCourseResult.Match(
            course => Ok(new CourseResponse(course.Id.ToString(), course.Title)),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> ListCourses()
    {
        var query = new ListCoursesQuery();
        var getCoursesResult = await _mediator.Send(query);
        return getCoursesResult.Match(
            courses => Ok(courses.Select(course => new CourseResponse(course.Id.ToString(), course.Title))),
            Problem);
    }


}
