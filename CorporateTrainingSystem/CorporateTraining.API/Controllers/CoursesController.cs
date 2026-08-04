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
   var courses = _context.Courses.ToList();
    return Ok(courses);
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


}
