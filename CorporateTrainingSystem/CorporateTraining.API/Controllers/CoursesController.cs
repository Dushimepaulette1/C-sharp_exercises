using Microsoft.AspNetCore.Mvc;
using CorporateTraining.API.Models;
using CorporateTraining.API.Data;
namespace CorporateTraining.API.Controllers;

[ApiController]
[Route("courses")]
public class CoursesController : ControllerBase
{ 
  private readonly TrainingContext _context;
  public CoursesController(TrainingContext context)
  {
    _context = context;
  }
  [HttpGet]
public IActionResult GetCourses()
{
    return Ok(_courseService.GetAllCourses());
}
[HttpPost]
public IActionResult CreateCourse(TrainingCourse course)
{
_context.Courses.Add(course);
_context.SaveChanges();
return Ok(course);
}
[HttpGet("{id}")]
public IActionResult GetCourse(int id)
{
    var course = _context.Courses.FirstOrDefault(c => c.Id == id);

    if(course == null)
    {
        return NotFound();
    }
    return Ok(course);
}
[HttpPut("{id}")]
public IActionResult UpdateCourse(int id, TrainingCourse updatedCourse)
{
    var course = _context.Courses.FirstOrDefault(c => c.Id == id);

    if(course == null)
    {
        return NotFound();
    }

    course.Title = updatedCourse.Title;
    course.Description = updatedCourse.Description;
    course.Duration = updatedCourse.Duration;
    course.Instructor = updatedCourse.Instructor;
    course.MaxCapacity = updatedCourse.MaxCapacity;
    course.Prerequisites = updatedCourse.Prerequisites;

    _context.SaveChanges();

    return Ok(course);
}
[HttpDelete("{id}")]
public IActionResult DeleteCourse(int id)
{
  bool deleted = _courseService.DeleteCourse(id);

    if (!deleted)
        return NotFound();

    return NoContent();
}

}
