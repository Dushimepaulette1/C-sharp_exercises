using Microsoft.AspNetCore.Mvc;
using CorporateTraining.API.Data;

namespace CorporateTraining.API.Controllers;

[ApiController]
[Route("courses")]
public class CoursesController : ControllerBase
{
  [HttpGet]
public IActionResult GetCourses()
{
    var courses = CourseRepository.GetAllCourses();

    return Ok(courses);
}
[HttpGet("{id:int}")]
public IActionResult GetCourse(int id ){
  var course = CourseRepository.GetAllCourses().FirstOrDefault(c => c.Id == id);
  return Ok(course);
}
}