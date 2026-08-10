using Microsoft.AspNetCore.Mvc;
using CorporateTraining.API.DTOs;
using CorporateTraining.API.Services;

namespace CorporateTraining.API.Controllers;

[ApiController]
[Route("courses")]
public class CoursesController : ControllerBase
{
  private readonly CourseService _courseService;

  public CoursesController(CourseService courseService)
  {
    _courseService = courseService;
  }
  [HttpGet]
public IActionResult GetCourses()
{
    var courses = _courseService.GetAllCourses();
    return Ok(courses);
}
[HttpPost]
public IActionResult CreateCourse(CreateCourseDto dto)
{
var course =  _courseService.CreateCourse(dto);
return Ok(course);
}
[HttpGet("{id}")]
public IActionResult GetCourse(int id)
{
    var course = _courseService.GetCourseById(id);

    if(course == null)
    {
        return NotFound();
    }
    return Ok(course);
}
[HttpPut("{id}")]
public IActionResult UpdateCourse(int id, UpdateCourseDto dto)
{
    var updatedCourse =  _courseService.UpdateCourse(id,dto);

    if(updatedCourse == null)
    {
        return NotFound();
    }
    return Ok(updatedCourse);
}
[HttpDelete("{id}")]
public IActionResult DeleteCourse(int id)
{
   var deleted = _courseService.DeleteCourse(id);

    if (!deleted)
        return NotFound();

    return NoContent();
}

}
